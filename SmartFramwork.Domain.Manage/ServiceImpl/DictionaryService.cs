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
	public class DictionaryService : BaseService<DictionaryEntity>, IDictionaryService
	{
		private readonly ILogger<DictionaryService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<DictionaryService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<DictionaryEntity>()
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
							   select new DictionaryModel
							   {
									ID = entity.id,
									Code = entity.code,
									ShortName = entity.short_name,
									Name = entity.name,
									Description = entity.description,
									ParentID = entity.parent_id,
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

		#region 新建字典表
		public void Create(DictionaryModel model)
		{
			try
			{
				var entity = new DictionaryEntity();				
				entity.id = GetUid(DictionaryEntity.TableName).ToInt32();
				entity.code = model.Code;
				entity.short_name = model.ShortName;
				entity.name = model.Name;
				entity.description = model.Description;
				entity.parent_id = model.ParentID;
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

		#region 获取字典表
		public DictionaryModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new DictionaryModel()
				{
					ID = entity.id,
					Code = entity.code,
					ShortName = entity.short_name,
					Name = entity.name,
					Description = entity.description,
					ParentID = entity.parent_id,
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

		#region 修改字典表
		public void Edit(DictionaryModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.code = model.Code;
			entity.short_name = model.ShortName;
			entity.name = model.Name;
			entity.description = model.Description;
			entity.parent_id = model.ParentID;
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
