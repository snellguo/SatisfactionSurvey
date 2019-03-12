using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.SatisfactionSurvey.Models
{
	/// <summary>
	/// 满意度调查
	/// 满意度调查
	/// </summary>
	public class SatisfactionSurveyModel
	{
		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 项目名称
		/// 项目名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_ProjectName")]
		public string ProjectName { get; set; }

		/// <summary>
		/// 合同号
		/// 合同号
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_ContractNum")]
		public string ContractNum { get; set; }

		/// <summary>
		/// 建设单位
		/// 建设单位
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_BuildUnit")]
		public string BuildUnit { get; set; }

        /// <summary>
        /// 姓名
        /// 姓名
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Name")]
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// 部门
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Department")]
		public string Department { get; set; }

		/// <summary>
		/// 职位
		/// 职位
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Position")]
		public string Position { get; set; }

		/// <summary>
		/// 电话
		/// 电话
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Telephone")]
		public string Telephone { get; set; }

		/// <summary>
		/// 施工质量分
		/// 施工质量分
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Shigong")]
		public string Shigong { get; set; }

		/// <summary>
		/// 服务态度分
		/// 服务态度分
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Service")]
		public string Service { get; set; }

		/// <summary>
		/// 技术能力分
		/// 技术能力分
		/// </summary>
        
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Technology")]
		public string Technology { get; set; }

		/// <summary>
		/// 安排条理性分
		/// 安排条理性分
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Orderliness")]
		public string Orderliness { get; set; }

		/// <summary>
		/// 沟通能力分
		/// 沟通能力分
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Communicate")]
		public string Communicate { get; set; }

        /// <summary>
        /// 进场日期
        /// 进场日期
        /// </summary>
        [Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Approach")]
        public DateTime? Approach { get; set; }

        /// <summary>
        /// 竣工日期
        /// 竣工日期
        /// </summary>
        [Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Completed")]
		public DateTime? Completed { get; set; }

		/// <summary>
		/// 改进意见
		/// 改进意见
		/// </summary>
		[StringLength(500, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Opinion")]
		public string Opinion { get; set; }

        /// <summary>
        /// 遗留问题
        /// 遗留问题
        /// </summary>
        [StringLength(500, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Problem")]
		public string Problem { get; set; }

		/// <summary>
		/// 客户代表
		/// 客户代表
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_Customer")]
		public string Customer { get; set; }

		/// <summary>
		/// 被考核人
		/// 被考核人
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_CheckObject")]
		public string CheckObject { get; set; }

		/// <summary>
		/// 考核日期
		/// 考核日期
		/// </summary>
		[Display(Name = "SatisfactionSurvey_SatisfactionSurveyModel_CheckDate")]
		public DateTime? CheckDate { get; set; }

	}
}