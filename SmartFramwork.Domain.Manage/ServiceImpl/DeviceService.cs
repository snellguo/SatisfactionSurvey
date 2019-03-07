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
	public class DeviceService : BaseService<DeviceEntity>, IDeviceService
	{
		private readonly ILogger<DeviceService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<DeviceService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<DeviceModel>()
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
                var driveTypes = _repo.DbContext.Set<DriveTypeEntity>();

                //var list = FindByPage(pageExp.Where, pageExp.orderBy, pageExp.isAsc, pageExp.pageIndex, pageExp.pageSize, out pageExp.total);

                //转换对象
                var query = (from entity in _repo.DbSet
                             join d in driveTypes on entity.type
                             equals d.code_value into dds
                             from dd in dds.DefaultIfEmpty()
                             select new DeviceModel
                               {
                                   ID = entity.id,
                                   Name = entity.name,
                                   Account = entity.account,
                                   Password = entity.password,
                                   Ip = entity.ip,
                                   Port = entity.port.ToString(),
                                   Model = entity.model,
                                   Brand = entity.brand,
                                   Type = entity.type,
                                   TypeName = dd.code_name,
                               });

				result.pageIndex = pageExp.pageIndex;
				result.records = pageExp.total = query.Where(pageExp.Where).Count();
				result.total = Convert.ToInt32(Math.Ceiling((double)pageExp.total / (double)pageExp.pageSize));
                result.rows = query.Where(pageExp.Where).OrderBy(pageExp.orderBy, pageExp.isAsc)
                    .Skip(pageExp.pageSize * (pageExp.pageIndex - 1))
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

		#region 新建设备信息
		public void Create(DeviceModel model)
		{
			try
			{
				var entity = new DeviceEntity();
				entity.id = GetUid(DeviceEntity.TableName).ToInt32();
				entity.name = model.Name;
				entity.account = model.Account;
				entity.password = model.Password;
				entity.ip = model.Ip;
				if (!string.IsNullOrWhiteSpace(model.Port))
				{
					entity.port = Convert.ToByte(model.Port);
				}
				entity.model = model.Model;
				entity.brand = model.Brand;
				entity.type = model.Type;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取设备信息
		public DeviceModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new DeviceModel()
				{
					ID = entity.id,
					Name = entity.name,
					Account = entity.account,
					Password = entity.password,
					Ip = entity.ip,
					Port = entity.port.ToString(),
					Model = entity.model,
					Brand = entity.brand,
					Type = entity.type,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改设备信息
		public void Edit(DeviceModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.name = model.Name;
			entity.account = model.Account;
			entity.password = model.Password;
			entity.ip = model.Ip;
			if (!string.IsNullOrWhiteSpace(model.Port))
			{
				entity.port = Convert.ToByte(model.Port);
			}
			else
			{
				entity.port = null;
			}
			entity.model = model.Model;
			entity.brand = model.Brand;
			entity.type = model.Type;

			Edit(entity);
		}
		#endregion

		#region 获取设备列表
		/// <summary>
		/// 根据类型返回所有的数据
		/// </summary>
		/// <param name="pageIndex">页码</param>
		/// <param name="pageSize">页大小</param>
		/// <param name="ctiid">ctiid</param>
		/// <returns></returns>
		public object GetListByPage(int pageIndex, int pageSize, int? ctiid)
		{
			try
			{
				int total = 0;
				IList<DeviceEntity> list;
				if (ctiid != null)
				{
					list = FindByPage(n => n.cti_id == ctiid, "id", true, pageIndex, pageSize, out total);
				}
				else
				{
					list = FindByPage(n => true, "id", true, pageIndex, pageSize, out total);
				}

				//转换对象
				var data = (from entity in list
							select new DeviceModel
							{
								ID = entity.id,
								Name = entity.name,
								Account = entity.account,
								Password = entity.password,
								Ip = entity.ip,
								Port = entity.port.ToString(),
								Model = entity.model,
								Brand = entity.brand,
								Type = entity.type,
							}).ToList();

				return new
				{
					code = 0,
					msg = "success",
					pageIndex = pageIndex,
					pageSize = pageSize,
					total = total,
					curSize = data.Count,
					data = data
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				throw ex;
			}
		}
		#endregion

		#region 验证分机号是否存在
		public bool CheckUnique(string name)
		{
			var entity = FindByWhere(n => n.name == name, "id", true).FirstOrDefault();
			if (entity == null)
				return false;
			else
				return true;
		}
		#endregion
	}
}
