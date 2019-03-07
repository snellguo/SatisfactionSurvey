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
	public class RolePermissionService : BaseService<RolePermissionEntity>, IRolePermissionService
	{
		private readonly ILogger<RolePermissionService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<RolePermissionService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<RolePermissionEntity>()
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
							   select new RolePermissionModel
							   {
									ID = entity.id,
									RoleID = entity.role_id,
									PermissionID = entity.permission_id,
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

		#region 新建角色权限关系表
		public void Create(RolePermissionModel model)
		{
			try
			{
				var entity = new RolePermissionEntity();				
				entity.id = GetUid(RolePermissionEntity.TableName).ToInt32();
				entity.role_id = model.RoleID;
				entity.permission_id = model.PermissionID;
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

		#region 获取角色权限关系表
		public RolePermissionModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new RolePermissionModel()
				{
					ID = entity.id,
					RoleID = entity.role_id,
					PermissionID = entity.permission_id,
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

		#region 修改角色权限关系表
		public void Edit(RolePermissionModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.role_id = model.RoleID;
			entity.permission_id = model.PermissionID;
			entity.creator_id = model.CreatorID;
			entity.creator_name = model.CreatorName;
			entity.creation_date = model.CreationDate;
			entity.modifier_id = model.ModifierID;
			entity.modifier_name = model.ModifierName;
			entity.modification_date = model.ModificationDate;

			Edit(entity);
		}
		#endregion
	}
}
