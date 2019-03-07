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
	public class DepartmentSettingService : BaseService<DepartmentSettingEntity>, IDepartmentSettingService
	{
		private readonly ILogger<DepartmentSettingService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<DepartmentSettingService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<DepartmentSettingEntity>()
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
						if (r.field == "code" && !string.IsNullOrWhiteSpace(r.data))
						{
							var code = r.data.ToInt32();
							pageExp.Where = pageExp.Where.And(n => n.code==code);
						}

					}
				}

				var result = new PageResultModel();

				var list = FindByPage(pageExp.Where, pageExp.orderBy, pageExp.isAsc, pageExp.pageIndex, pageExp.pageSize, out pageExp.total);

				IUserService uSvr = new UserService();
				var uList = uSvr.FindByWhere(n => list.Where(k => k.type == 2).Select(m => m.value).Contains(n.id), "id", true);

				IDepartmentService dSvr = new DepartmentService();
				var dList = dSvr.FindByWhere(n => list.Where(k => k.type == 1).Select(m => m.value).Contains(n.id), "id", true);

				IList<DepartmentSettingModel> mlist = new List<DepartmentSettingModel>();

				foreach (var entity in list)
				{
					var m = new DepartmentSettingModel();
					m.ID = entity.id;
					m.OrganizationID = entity.organization_id;
					m.Type = entity.type;
					m.Value = entity.value;
					if (entity.type == 2)
					{
						var u= uList.Where(n => n.id == entity.value).FirstOrDefault();
						if (u!=null)
						{
							m.value_name = u.name;
						} else {
							m.value_name = "";
						}
					}
					else
					{
						var d = dList.Where(n => n.id == entity.value).FirstOrDefault();
						if (d != null)
						{
							m.value_name = d.name;
						}
						else
						{
							m.value_name = "";
						}
					}
					m.Code = entity.code;
					mlist.Add(m);
				}

				//转换对象
				result.rows = mlist;


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

		#region 新建部门配置
		public void Create(DepartmentSettingModel model)
		{
			try
			{
				var entity = new DepartmentSettingEntity();
				entity.id = GetUid(DepartmentSettingEntity.TableName).ToInt32();
				entity.organization_id = model.OrganizationID;
				entity.type = model.Type;
				entity.value = model.Value;
				entity.code = model.Code;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取部门配置
		public DepartmentSettingModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new DepartmentSettingModel()
				{
					ID = entity.id,
					OrganizationID = entity.organization_id,
					Type = entity.type,
					Value = entity.value,
					Code = entity.code,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改部门配置
		public void Edit(DepartmentSettingModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.organization_id = model.OrganizationID;
			entity.type = model.Type;
			entity.value = model.Value;
			entity.code = model.Code;

			Edit(entity);
		}
		#endregion

		public void SetTop(int deptid, int userid)
		{
			_repo.DbContext.Database.ExecuteSqlCommand("update base_department_user set is_top=1,top_time=NOW() where user_id=@userid and department_id=@deptid",
				_repo.DbContext.CreateParameter("@deptid", deptid),
				_repo.DbContext.CreateParameter("@userid", userid)
				);
		}
	}
}
