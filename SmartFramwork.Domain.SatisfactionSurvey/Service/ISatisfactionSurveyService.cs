﻿using SmartFramwork.Core.Service;
using SmartFramwork.Domain.SatisfactionSurvey.Entities;
using SmartFramwork.Domain.SatisfactionSurvey.Models;
using SmartFramwork.Web.Models;
using System.Collections.Generic;

namespace SmartFramwork.Domain.SatisfactionSurvey.Service
{
	/// <summary>
	/// 用户
	/// </summary>
	public interface ISatisfactionSurveyService:IBaseService<SatisfactionSurveyEntity>
	{
		/// <summary>
		/// 分页列表
		/// </summary>
		/// <param name="page"></param>
		/// <returns></returns>
		PageResultModel GetPageList(JqGridModel model);

		/// <summary>
		/// 创建用户
		/// </summary>
		/// <param name="model">Model</param>
		void Create(SatisfactionSurveyModel model);

		/// <summary>
		/// 编辑
		/// </summary>
		/// <param name="model">Model</param>
		void Edit(SatisfactionSurveyModel model);

		/// <summary>
		/// 获取模型
		/// </summary>
		/// <param name="keyValue">主键</param>
		/// <returns>Model</returns>
		SatisfactionSurveyModel GetModelByID(params object[] keyValues);
	}
}
