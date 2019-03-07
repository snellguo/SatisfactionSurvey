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
using Microsoft.EntityFrameworkCore;

namespace SmartFramwork.Domain.Manage.ServiceImpl
{
	public class PermissionService : BaseService<PermissionEntity>, IPermissionService
    {
        //IRolePermissionService rolePermissionService = new RolePermissionService();
        private readonly ILogger<PermissionService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<PermissionService>>();
        private readonly IRolePermissionService _rolePermissionService = GlobalVariable.ServiceProvider.GetService<IRolePermissionService>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<PermissionEntity>()
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
							//pageExp.Where = pageExp.Where.And(n => n.name.Contains(r.data));
						}

					}
				}

				var result = new PageResultModel();

				var list = FindByPage(pageExp.Where, pageExp.orderBy, pageExp.isAsc, pageExp.pageIndex, pageExp.pageSize, out pageExp.total);

				//转换对象
				result.rows = (from entity in list
							   select new PermissionModel
							   {
								   ID = entity.id,
								   AppID = entity.app_id,
								   MenuID = entity.menu_id,
								   Code = entity.code,
								   Name = entity.name,
								   Description = entity.description,
								   ParentID = entity.parent_id,
								   Icon = entity.icon,
								   Type = entity.type,
								   Script = entity.script,
								   Style = entity.style,
								   Activate = entity.activate,
								   Sort = entity.sort,
								   CreatorID = entity.creator_id,
								   CreatorName = entity.creator_name,
								   CreationDate = entity.creation_date,
								   ModifierID = entity.modifier_id,
								   ModifierName = entity.modifier_name,
								   ModificationDate = entity.modification_date,
							   }).ToList();


				result.pageIndex = pageExp.pageIndex;
				result.records = pageExp.total;
				result.total = Convert.ToInt32(Math.Ceiling((double)pageExp.total / (double)pageExp.pageSize));

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 新建操作权限表
		public void Create(PermissionModel model)
		{
			try
			{
				var entity = new PermissionEntity();
				entity.id = GetUid(PermissionEntity.TableName).ToInt32();
				entity.app_id = model.AppID;
				entity.menu_id = model.MenuID;
				entity.code = model.Code;
				entity.name = model.Name;
				entity.description = model.Description;
				entity.parent_id = model.ParentID;
				entity.icon = model.Icon;
				entity.type = model.Type;
				entity.script = model.Script;
				entity.style = model.Style;
				entity.activate = model.Activate;
				entity.sort = model.Sort;
				entity.creator_id = model.CreatorID;
				entity.creator_name = model.CreatorName;
				entity.creation_date = model.CreationDate;
				entity.modifier_id = model.ModifierID;
				entity.modifier_name = model.ModifierName;
				entity.modification_date = model.ModificationDate;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取操作权限表
		public PermissionModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new PermissionModel()
				{
					ID = entity.id,
					AppID = entity.app_id,
					MenuID = entity.menu_id,
					Code = entity.code,
					Name = entity.name,
					Description = entity.description,
					ParentID = entity.parent_id,
					Icon = entity.icon,
					Type = entity.type,
					Script = entity.script,
					Style = entity.style,
					Activate = entity.activate,
					Sort = entity.sort,
					CreatorID = entity.creator_id,
					CreatorName = entity.creator_name,
					CreationDate = entity.creation_date,
					ModifierID = entity.modifier_id,
					ModifierName = entity.modifier_name,
					ModificationDate = entity.modification_date,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改操作权限表
		public void Edit(PermissionModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.app_id = model.AppID;
			entity.menu_id = model.MenuID;
			entity.code = model.Code;
			entity.name = model.Name;
			entity.description = model.Description;
			entity.parent_id = model.ParentID;
			entity.icon = model.Icon;
			entity.type = model.Type;
			entity.script = model.Script;
			entity.style = model.Style;
			entity.activate = model.Activate;
			entity.sort = model.Sort;
			entity.creator_id = model.CreatorID;
			entity.creator_name = model.CreatorName;
			entity.creation_date = model.CreationDate;
			entity.modifier_id = model.ModifierID;
			entity.modifier_name = model.ModifierName;
			entity.modification_date = model.ModificationDate;

			Edit(entity);
		}
		#endregion



		#region 获取用户权限
		public IList<PermissionInfo> GetPermissionByUserID(int id)
		{
			var sql = $"SELECT * from base_permission  where base_permission.id in (SELECT permission_id FROM base_role_permission where role_id in(SELECT role_id FROM base_user_role  where user_id = @UserID))";
			return (from item in _dbSet.FromSql(sql, _repo.DbContext.CreateParameter("@UserID", id))
					select new PermissionInfo
					{
						pmsnid = item.id,
						code = item.code,
						menuid = item.menu_id,
						name = item.name,
						description = item.description,
						script = item.script,
						style = item.style,
						sort = item.sort,
						type = item.type,
						icon = item.icon,
						parent_id = item.parent_id,
						activate = item.activate,
						appid = item.app_id

					}).ToList();
		}
        #endregion


        public IList<PermissionModel> GetPermissionByRole(IList<RoleModel> role)
        {
            var roleList = (from item in role select item.ID).Distinct();

            var rolePmsnList = _rolePermissionService.FindByWhere(n => roleList.Contains(n.role_id), "id", false);

            var rplist = (from item in rolePmsnList select item.permission_id).Distinct();

            var entityList = FindByWhere(n => rplist.Contains(n.id), "id", false);

            return (from entity in entityList
                    select new PermissionModel()
                    {
                        ID = entity.id,
                        AppID = entity.app_id,
                        MenuID = entity.menu_id,
                        Code = entity.code,
                        Name = entity.name,
                        Description = entity.description,
                        ParentID = entity.parent_id,
                        Icon = entity.icon,
                        Type = entity.type,
                        Script = entity.script,
                        Style = entity.style,
                        Activate = entity.activate,
                        Sort = entity.sort,
                        CreatorID = entity.creator_id,
                        CreatorName = entity.creator_name,
                        CreationDate = entity.creation_date,
                        ModifierID = entity.modifier_id,
                        ModifierName = entity.modifier_name,
                        ModificationDate = entity.modification_date,
                    }).ToList();
        }

        public IList<PermissionModel> GetPermissionByAllAndForChecked(int roleid)
        {
            //获取角色与权限的关联
            var rolePmsn = _rolePermissionService.FindByWhere(n => n.role_id == roleid, "id", true);
            //获取所以得权限
            var pmsnAll = FindByWhere(n => n.activate == 1, "sort", true);


            var pmsns = from item in pmsnAll
                        join role in rolePmsn on item.id equals role.permission_id into temp
                        from n in temp.DefaultIfEmpty()
                        select new PermissionModel()
                        {
                            ID = item.id,
                            AppID = item.app_id,
                            MenuID = item.menu_id,
                            Code = item.code,
                            Name = item.name,
                            Description = item.description,
                            ParentID = item.parent_id,
                            Icon = item.icon,
                            Type = item.type,
                            Script = item.script,
                            Style = item.style,
                            Activate = item.activate,
                            Sort = item.sort,
                            CreatorID = item.creator_id,
                            CreatorName = item.creator_name,
                            CreationDate = item.creation_date,
                            ModifierID = item.modifier_id,
                            ModifierName = item.modifier_name,
                            ModificationDate = item.modification_date,
                            isChecked = n == null ? false : true
                        };

            return pmsns.ToList();

        }
    }
}
