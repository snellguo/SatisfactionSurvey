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
	public class DriveTypeService : BaseService<DriveTypeEntity>, IDriveTypeService
	{
		private readonly ILogger<DriveTypeService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<DriveTypeService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<DriveTypeEntity>()
				{
					pageIndex = model.page,
					pageSize = model.rows,
					Where = n => true,
					orderBy = "id",
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
							   select new DriveTypeModel
							   {
									ID = entity.id,
									CodeValue = entity.code_value,
									CodeName = entity.code_name,
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

		#region 新建设备类型代码表
		public void Create(DriveTypeModel model)
		{
			try
			{
				var entity = new DriveTypeEntity();				
				entity.id = GetUid(DriveTypeEntity.TableName).ToInt32();
				entity.code_value = model.CodeValue;
				entity.code_name = model.CodeName;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取设备类型代码表
		public DriveTypeModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new DriveTypeModel()
				{
					ID = entity.id,
					CodeValue = entity.code_value,
					CodeName = entity.code_name,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改设备类型代码表
		public void Edit(DriveTypeModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.code_value = model.CodeValue;
			entity.code_name = model.CodeName;

			Edit(entity);
		}
		#endregion
	}
}
