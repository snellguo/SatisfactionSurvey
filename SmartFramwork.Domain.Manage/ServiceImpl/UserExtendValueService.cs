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
	public class UserExtendValueService : BaseService<UserExtendValueEntity>, IUserExtendValueService
	{
		private readonly ILogger<UserExtendValueService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<UserExtendValueService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<UserExtendValueEntity>()
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
							   select new UserExtendValueModel
							   {
									ID = entity.id,
									UserID = entity.user_id,
									ExtendID = entity.extend_id,
									ExtendName = entity.extend_name,
									Value = entity.value,
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

		#region 新建用户扩展值
		public void Create(UserExtendValueModel model)
		{
			try
			{
				var entity = new UserExtendValueEntity();				
				entity.id = GetUid(UserExtendValueEntity.TableName).ToInt32();
				entity.user_id = model.UserID;
				entity.extend_id = model.ExtendID;
				entity.extend_name = model.ExtendName;
				entity.value = model.Value;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取用户扩展值
		public UserExtendValueModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new UserExtendValueModel()
				{
					ID = entity.id,
					UserID = entity.user_id,
					ExtendID = entity.extend_id,
					ExtendName = entity.extend_name,
					Value = entity.value,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改用户扩展值
		public void Edit(UserExtendValueModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.user_id = model.UserID;
			entity.extend_id = model.ExtendID;
			entity.extend_name = model.ExtendName;
			entity.value = model.Value;

			Edit(entity);
		}
		#endregion
	}
}
