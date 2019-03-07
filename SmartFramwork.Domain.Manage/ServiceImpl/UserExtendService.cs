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
	public class UserExtendService : BaseService<UserExtendEntity>, IUserExtendService
	{
		private readonly ILogger<UserExtendService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<UserExtendService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<UserExtendEntity>()
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
							   select new UserExtendModel
							   {
									ID = entity.id,
									Name = entity.name,
									Field = entity.field,
									Type = entity.type,
									IsShow = entity.is_show,
									IsSensitive = entity.is_sensitive,
									IsDesktop = entity.is_desktop,
									Sort = entity.sort,
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

		#region 新建员工扩展表
		public void Create(UserExtendModel model)
		{
			try
			{
				var entity = new UserExtendEntity();				
				entity.id = GetUid(UserExtendEntity.TableName).ToInt32();
				entity.name = model.Name;
				entity.field = model.Field;
				entity.type = model.Type;
				entity.is_show = model.IsShow;
				entity.is_sensitive = model.IsSensitive;
				entity.is_desktop = model.IsDesktop;
				entity.sort = model.Sort;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取员工扩展表
		public UserExtendModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new UserExtendModel()
				{
					ID = entity.id,
					Name = entity.name,
					Field = entity.field,
					Type = entity.type,
					IsShow = entity.is_show,
					IsSensitive = entity.is_sensitive,
					IsDesktop = entity.is_desktop,
					Sort = entity.sort,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改员工扩展表
		public void Edit(UserExtendModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.name = model.Name;
			entity.field = model.Field;
			entity.type = model.Type;
			entity.is_show = model.IsShow;
			entity.is_sensitive = model.IsSensitive;
			entity.is_desktop = model.IsDesktop;
			entity.sort = model.Sort;

			Edit(entity);
		}
		#endregion
	}
}
