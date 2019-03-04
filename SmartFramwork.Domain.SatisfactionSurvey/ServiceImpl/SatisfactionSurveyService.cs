using Microsoft.Extensions.Logging;
using SmartFramwork.Core.Service;
using SmartFramwork.Core.Utils;
using SmartFramwork.Domain.SatisfactionSurvey.Entities;
using SmartFramwork.Domain.SatisfactionSurvey.Models;
using SmartFramwork.Domain.SatisfactionSurvey.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SmartFramwork.Web.Models;
using SmartFramwork.Core;
using SmartFramwork.Web.Utils;
using Microsoft.EntityFrameworkCore;


namespace SmartFramwork.Domain.SatisfactionSurvey.ServiceImpl
{
	public class SatisfactionSurveyService : BaseService<SatisfactionSurveyEntity>, ISatisfactionSurveyService
	{
		private readonly ILogger<SatisfactionSurveyService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<SatisfactionSurveyService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<SatisfactionSurveyEntity>()
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
							   select new SatisfactionSurveyModel
							   {
									ID = entity.id,
									ProjectName = entity.project_name,
									ContractNum = entity.contract_num,
									BuildUnit = entity.build_unit,
									Name = entity.name,
									Department = entity.department,
									Position = entity.position,
									Telephone = entity.telephone,
									Shigong = entity.shigong,
									Service = entity.service,
									Technology = entity.technology,
									Orderliness = entity.orderliness,
									Communicate = entity.communicate,
									Approach = entity.approach,
									Completed = entity.completed,
									Opinion = entity.opinion,
									Problem = entity.problem,
									Customer = entity.customer,
									CheckObject = entity.check_object,
									CheckDate = entity.check_date,
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

		#region 新建满意度调查
		public void Create(SatisfactionSurveyModel model)
		{
			try
			{
				var entity = new SatisfactionSurveyEntity();				
				entity.id = GetUid(SatisfactionSurveyEntity.TableName).ToInt32();
				entity.project_name = model.ProjectName;
				entity.contract_num = model.ContractNum;
				entity.build_unit = model.BuildUnit;
				entity.name = model.Name;
				entity.department = model.Department;
				entity.position = model.Position;
				entity.telephone = model.Telephone;
				entity.shigong = model.Shigong;
				entity.service = model.Service;
				entity.technology = model.Technology;
				entity.orderliness = model.Orderliness;
				entity.communicate = model.Communicate;
				entity.approach = model.Approach;
				entity.completed = model.Completed;
				entity.opinion = model.Opinion;
				entity.problem = model.Problem;
				entity.customer = model.Customer;
				entity.check_object = model.CheckObject;
				entity.check_date = model.CheckDate;

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取满意度调查
		public SatisfactionSurveyModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new SatisfactionSurveyModel()
				{
					ID = entity.id,
					ProjectName = entity.project_name,
					ContractNum = entity.contract_num,
					BuildUnit = entity.build_unit,
					Name = entity.name,
					Department = entity.department,
					Position = entity.position,
					Telephone = entity.telephone,
					Shigong = entity.shigong,
					Service = entity.service,
					Technology = entity.technology,
					Orderliness = entity.orderliness,
					Communicate = entity.communicate,
					Approach = entity.approach,
					Completed = entity.completed,
					Opinion = entity.opinion,
					Problem = entity.problem,
					Customer = entity.customer,
					CheckObject = entity.check_object,
					CheckDate = entity.check_date,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改满意度调查
		public void Edit(SatisfactionSurveyModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.project_name = model.ProjectName;
			entity.contract_num = model.ContractNum;
			entity.build_unit = model.BuildUnit;
			entity.name = model.Name;
			entity.department = model.Department;
			entity.position = model.Position;
			entity.telephone = model.Telephone;
			entity.shigong = model.Shigong;
			entity.service = model.Service;
			entity.technology = model.Technology;
			entity.orderliness = model.Orderliness;
			entity.communicate = model.Communicate;
			entity.approach = model.Approach;
			entity.completed = model.Completed;
			entity.opinion = model.Opinion;
			entity.problem = model.Problem;
			entity.customer = model.Customer;
			entity.check_object = model.CheckObject;
			entity.check_date = model.CheckDate;

			Edit(entity);
		}
		#endregion
	}
}
