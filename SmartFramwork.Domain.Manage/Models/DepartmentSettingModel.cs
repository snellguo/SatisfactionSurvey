using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 部门配置
	/// 
	/// </summary>
	public partial class DepartmentSettingModel
	{
		/// <summary>
		/// 编号
		/// 
		/// </summary>
		[Display(Name = "Manage_DepartmentSettingModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 机构/公司
		/// 
		/// </summary>
		[Display(Name = "Manage_DepartmentSettingModel_OrganizationID")]
		public int? OrganizationID { get; set; }

		/// <summary>
		/// 类型
		/// 1部门2成员
		/// </summary>
		[Display(Name = "Manage_DepartmentSettingModel_Type")]
		public int? Type { get; set; }

		/// <summary>
		/// 值
		/// 
		/// </summary>
		[Display(Name = "Manage_DepartmentSettingModel_Value")]
		public int? Value { get; set; }

		public string value_name { get; set; }

		/// <summary>
		/// 代码
		/// 1敏感11白名单，2隐藏22可以查看，3限制33额外
		/// </summary>
		[Display(Name = "Manage_DepartmentSettingModel_Code")]
		public int? Code { get; set; }

	}

	public partial class DepartmentSettingModel
	{
	
	}
}