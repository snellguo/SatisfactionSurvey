using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.SatisfactionSurvey.Entities
{
	/// <summary>
	/// 满意度调查
	/// 满意度调查
	/// </summary>
	public class SatisfactionSurveyEntity
	{
		public const string TableName = "SatisfactionSurvey";

		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 项目名称
		/// 项目名称
		/// </summary>
		public string project_name { get; set; } = "测试";

        /// <summary>
        /// 合同号
        /// 合同号
        /// </summary>
        public string contract_num { get; set; }

		/// <summary>
		/// 建设单位
		/// 建设单位
		/// </summary>
		public string build_unit { get; set; }

		/// <summary>
		/// 姓名
		/// 姓名
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 部门
		/// 部门
		/// </summary>
		public string department { get; set; }

		/// <summary>
		/// 职位
		/// 职位
		/// </summary>
		public string position { get; set; }

		/// <summary>
		/// 电话
		/// 电话
		/// </summary>
		public string telephone { get; set; }

		/// <summary>
		/// 施工质量分
		/// 施工质量分
		/// </summary>
		public string shigong { get; set; }

		/// <summary>
		/// 服务态度分
		/// 服务态度分
		/// </summary>
		public string service { get; set; }

		/// <summary>
		/// 技术能力分
		/// 技术能力分
		/// </summary>
		public string technology { get; set; }

		/// <summary>
		/// 安排条理性分
		/// 安排条理性分
		/// </summary>
		public string orderliness { get; set; }

		/// <summary>
		/// 沟通能力分
		/// 沟通能力分
		/// </summary>
		public string communicate { get; set; }

		/// <summary>
		/// 进场日期
		/// 进场日期
		/// </summary>
		public DateTime? approach { get; set; }

		/// <summary>
		/// 竣工日期
		/// 竣工日期
		/// </summary>
		public DateTime? completed { get; set; }

		/// <summary>
		/// 改进意见
		/// 改进意见
		/// </summary>
		public string opinion { get; set; }

		/// <summary>
		/// 遗留问题
		/// 遗留问题
		/// </summary>
		public string problem { get; set; }

		/// <summary>
		/// 客户代表
		/// 客户代表
		/// </summary>
		public string customer { get; set; }

		/// <summary>
		/// 被考核人
		/// 被考核人
		/// </summary>
		public string check_object { get; set; }

		/// <summary>
		/// 考核日期
		/// 考核日期
		/// </summary>
		public DateTime? check_date { get; set; }

	}
}