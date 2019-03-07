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
	public class UserRoleService : BaseService<UserRoleEntity>, IUserRoleService
	{
		private readonly ILogger<UserRoleService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<UserRoleService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<UserRoleEntity>()
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
							   select new UserRoleModel
							   {
									ID = entity.id,
									AppID = entity.app_id,
									OrganizationID = entity.organization_id,
									UserID = entity.user_id,
									RoleID = entity.role_id,
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

		#region 新建用户关系角色表
		public void Create(UserRoleModel model)
		{
			try
			{
				var entity = new UserRoleEntity();				
				entity.id = GetUid(UserRoleEntity.TableName).ToInt32();
				entity.app_id = model.AppID;
				entity.organization_id = model.OrganizationID;
				entity.user_id = model.UserID;
				entity.role_id = model.RoleID;
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

		#region 获取用户关系角色表
		public UserRoleModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new UserRoleModel()
				{
					ID = entity.id,
					AppID = entity.app_id,
					OrganizationID = entity.organization_id,
					UserID = entity.user_id,
					RoleID = entity.role_id,
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

		#region 修改用户关系角色表
		public void Edit(UserRoleModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.app_id = model.AppID;
			entity.organization_id = model.OrganizationID;
			entity.user_id = model.UserID;
			entity.role_id = model.RoleID;
			entity.creator_id = model.CreatorID;
			entity.creator_name = model.CreatorName;
			entity.creation_date = model.CreationDate;
			entity.modifier_id = model.ModifierID;
			entity.modifier_name = model.ModifierName;
			entity.modification_date = model.ModificationDate;

			Edit(entity);
		}
		#endregion

        public void CreateByUserID(int UserID,IList<int?> Roles)
        {
            var list = FindByWhere(n => n.user_id == UserID, "id", true);
            foreach (var item in list)
            {
                Delete(item.id);
            }
            if (Roles != null)
            {
                foreach (var item in Roles)
                {
                    Create(new UserRoleEntity()
                    {
                        id = GetUid(UserRoleEntity.TableName).ToInt32(),
                        user_id = UserID,
                        role_id = item,
                        creation_date = DateTime.Now,
                        creator_id = SessionUtil.GetUserID().ToInt32(),
                        creator_name = SessionUtil.GetUserLoginName(),
                        modification_date = DateTime.Now,
                        modifier_id = SessionUtil.GetUserID().ToInt32(),
                        modifier_name = SessionUtil.GetUserLoginName(),
                    });
                }
            }
        }
	}
}
