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
	public class MenuService : BaseService<MenuEntity>, IMenuService
	{
		private readonly ILogger<MenuService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<MenuService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<MenuEntity>()
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
							   select new MenuModel
							   {
									ID = entity.id,
									AppID = entity.app_id,
									Name = entity.name,
									Description = entity.description,
									ParentID = entity.parent_id,
									Level = entity.level,
									Node = entity.node,
									Url = entity.url,
									Type = entity.type,
									Icon = entity.icon,
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

		#region 新建系统菜单表
		public void Create(MenuModel model)
		{
			try
			{
				var entity = new MenuEntity();				
				entity.id = GetUid(MenuEntity.TableName).ToInt32();
				entity.app_id = model.AppID;
				entity.name = model.Name;
				entity.description = model.Description;
				entity.parent_id = model.ParentID;
				entity.level = model.Level;
				entity.node = model.Node;
				entity.url = model.Url;
				entity.type = model.Type;
				entity.icon = model.Icon;
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

		#region 获取系统菜单表
		public MenuModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new MenuModel()
				{
					ID = entity.id,
					AppID = entity.app_id,
					Name = entity.name,
					Description = entity.description,
					ParentID = entity.parent_id,
					Level = entity.level,
					Node = entity.node,
					Url = entity.url,
					Type = entity.type,
					Icon = entity.icon,
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

		#region 修改系统菜单表
		public void Edit(MenuModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.app_id = model.AppID;
			entity.name = model.Name;
			entity.description = model.Description;
			entity.parent_id = model.ParentID;
			entity.level = model.Level;
			entity.node = model.Node;
			entity.url = model.Url;
			entity.type = model.Type;
			entity.icon = model.Icon;
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


		#region 获取菜单
		public IList<MenuInfo> GetMenuByPermission(IList<PermissionInfo> Permission)
		{
			var pid = Permission.Select(n => n.menuid).Distinct();
			return (from item in FindByWhere(n=> pid.Contains(n.id),"id",true) select new MenuInfo {
				menuid = item.id,
				appid = item.app_id,
				name = item.name,
				description = item.description,
				parent_id = item.parent_id,
				icon = item.icon,
				sort = item.sort,
				url = item.url
			}).ToList();
		}
		#endregion
	}
}
