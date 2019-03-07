using Microsoft.Extensions.Logging;
using SmartFramwork.Core.Service;
using SmartFramwork.Core.Utils;
using SmartFramwork.Domain.Manage.Entities;
using SmartFramwork.Domain.Manage.Models;
using SmartFramwork.Domain.Manage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SmartFramwork.Web.Models;
using SmartFramwork.Core;
using SmartFramwork.Web.Utils;

namespace SmartFramwork.Domain.Manage.ServiceImpl
{
	public class RoleService : BaseService<RoleEntity>, IRoleService
	{
		private readonly ILogger<RoleService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<RoleService>>();
		private readonly IOrganizationService organizationService = GlobalVariable.ServiceProvider.GetService<IOrganizationService>();
		private readonly IRolePermissionService _RolePermissionService = GlobalVariable.ServiceProvider.GetService<IRolePermissionService>();

        public int GetIdByName(string roleName)
        {
            var roles = FindByWhere(n => n.name == roleName, "id", true);
            if (roles.Count > 0)
                return roles.First().id;
            else
                return 0;
        }
        #region 获取页面列表
        public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<RoleModel>()
				{
					pageIndex = model.page,
					pageSize = model.rows,
					Where = n => true,
					orderBy = model.sidx,
					isAsc = model.sord == "asc",
				};
                if (model.search)
				{
					foreach (var r in model.filters.rules)
					{
						if (r.field == "keyValue" && !string.IsNullOrWhiteSpace(r.data))
						{
							pageExp.Where = pageExp.Where.And(n => n.Name.Contains(r.data));
						}

					}
				}
				var result = new PageResultModel();
                var OrgSet = _repo.DbContext.Set<OrganizationEntity>(); 
                 //转换对象
                 var query = (from entity in _repo.DbSet
                             join o in OrgSet on entity.organization_id
                               equals o.id into ros
                               from ro in ros.DefaultIfEmpty()
                               select new RoleModel
                               {
                                   ID = entity.id,
                                   AppID = entity.app_id,
                                   OrganizationID = entity.organization_id,
                                   Name = entity.name,
                                   Description = entity.description,
                                   SystemFlag = entity.system_flag,
                                   CreatorID = entity.creator_id,
                                   CreatorName = entity.creator_name,
                                   CreationDate = entity.creation_date,
                                   ModifierID = entity.modifier_id,
                                   ModifierName = entity.modifier_name,
                                   ModificationDate = entity.modification_date,
                                   OrgName = ro.name
							   });

                result.pageIndex = pageExp.pageIndex;
				result.records = pageExp.total = query.Count();
				result.total = Convert.ToInt32(Math.Ceiling((double)pageExp.total / (double)pageExp.pageSize));
                result.rows = query.Where(pageExp.Where).OrderBy(pageExp.orderBy, pageExp.isAsc)
                    .Skip((pageExp.pageIndex - 1) * pageExp.pageSize)
                    .Take(pageExp.pageSize).ToList();

                return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 新建角色表
		public void Create(RoleModel model)
		{
			try
			{
				var entity = new RoleEntity();				
				entity.id = GetUid(RoleEntity.TableName).ToInt32();
				entity.app_id = model.AppID;
				entity.organization_id = model.OrganizationID;
				entity.name = model.Name;
				entity.description = model.Description;
				entity.system_flag = model.SystemFlag;
				entity.creator_id = SessionUtil.GetUserID();
				entity.creator_name = SessionUtil.GetUserLoginName();
				entity.creation_date = DateTime.Now;
				entity.modifier_id = SessionUtil.GetUserID();
				entity.modifier_name = SessionUtil.GetUserLoginName();
				entity.modification_date = DateTime.Now;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取角色表
		public RoleModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

                return new RoleModel()
                {
                    ID = entity.id,
                    AppID = entity.app_id,
                    OrganizationID = entity.organization_id,
                    Name = entity.name,
                    Description = entity.description,
                    SystemFlag = entity.system_flag,
                    CreatorID = entity.creator_id,
                    CreatorName = entity.creator_name,
                    CreationDate = entity.creation_date,
                    ModifierID = entity.modifier_id,
                    ModifierName = entity.modifier_name,
                    ModificationDate = entity.modification_date,
                    OrgName = organizationService.GetNameById(entity.organization_id.ToInt32()),
                };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改角色表
		public void Edit(RoleModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.app_id = model.AppID;
			entity.organization_id = model.OrganizationID;
			entity.name = model.Name;
			entity.description = model.Description;
			entity.system_flag = model.SystemFlag;
			entity.creator_id = model.CreatorID;
			entity.creator_name = model.CreatorName;
			entity.creation_date = model.CreationDate;
			entity.modifier_id = model.ModifierID;
			entity.modifier_name = model.ModifierName;
			entity.modification_date = model.ModificationDate;

			Edit(entity);
		}
        #endregion

        public bool GrantRole(int roleid, string pmsnids)
        {

            try
            {
                var rolePmsn = _RolePermissionService.FindByWhere(n => n.role_id == roleid, "id", false);
                foreach (var item in rolePmsn)
                {
                    _RolePermissionService.Delete(item.id);
                }


                foreach (var s in pmsnids.Split(','))
                {
                    _RolePermissionService.Create(new RolePermissionEntity()
                    {
                        id = GetUid(RolePermissionEntity.TableName).ToInt32(),
                        role_id = roleid,
                        permission_id = s.ToInt32(),
                        creator_id = SessionUtil.GetUserID(),
                        creator_name = SessionUtil.GetUserLoginName(),
                        creation_date = DateTime.Now,
                        modifier_id = SessionUtil.GetUserID(),
                        modifier_name = SessionUtil.GetUserLoginName(),
                        modification_date = DateTime.Now,
                    });


                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RoleEntity> GetRoleByUserID(int UserID)
        {
            var userRoleSet = _repo.DbContext.Set<UserRoleEntity>()
                .Where(n => n.user_id.Equals(UserID));
            var query = (from entity in _repo.DbSet
                         join r in userRoleSet on entity.id
                         equals r.role_id into rrs
                         from rr in rrs.DefaultIfEmpty()
                         select new RoleEntity{});
            return query.ToList();
        }

        public List<RoleModel> GetList()
        {
            var OrgSet = _repo.DbContext.Set<OrganizationEntity>();

            return (from entity in _repo.DbSet
                    join o in OrgSet on entity.organization_id
                      equals o.id into ros
                    from ro in ros.DefaultIfEmpty()
                    select new RoleModel()
                    {
                        ID = entity.id,
                        AppID = entity.app_id,
                        OrganizationID = entity.organization_id,
                        Name = entity.name,
                        Description = entity.description,
                        SystemFlag = entity.system_flag,
                        CreatorID = entity.creator_id,
                        CreatorName = entity.creator_name,
                        CreationDate = entity.creation_date,
                        ModifierID = entity.modifier_id,
                        ModifierName = entity.modifier_name,
                        ModificationDate = entity.modification_date,
                        OrgName = ro.name,
                    }).ToList();
        }
    }
}
