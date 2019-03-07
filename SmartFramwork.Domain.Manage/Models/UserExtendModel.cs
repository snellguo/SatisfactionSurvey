using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 员工扩展表
	/// 员工扩展表
	/// </summary>
	public partial class UserExtendModel
	{
		/// <summary>
		/// 编号
		/// 
		/// </summary>
		[Display(Name = "Manage_UserExtendModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 名称
		/// 
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_UserExtendModel_Name")]
		public string Name { get; set; }

		/// <summary>
		/// 字段
		/// 
		/// </summary>
		[StringLength(100, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_UserExtendModel_Field")]
		public string Field { get; set; }

		/// <summary>
		/// 类型
		/// 1,系统2自定义
		/// </summary>
		[Display(Name = "Manage_UserExtendModel_Type")]
		public int? Type { get; set; }

		/// <summary>
		/// 是否展示
		/// 1展示0隐藏
		/// </summary>
		[Display(Name = "Manage_UserExtendModel_IsShow")]
		public int? IsShow { get; set; }

		/// <summary>
		/// 是否敏感数据
		/// 1展示0隐藏
		/// </summary>
		[Display(Name = "Manage_UserExtendModel_IsSensitive")]
		public int? IsSensitive { get; set; }

		/// <summary>
		/// 是否桌面展示
		/// 1展示0隐藏
		/// </summary>
		[Display(Name = "Manage_UserExtendModel_IsDesktop")]
		public int? IsDesktop { get; set; }

		/// <summary>
		/// 排序
		/// 
		/// </summary>
		[Display(Name = "Manage_UserExtendModel_Sort")]
		public int? Sort { get; set; }

	}

	public partial class UserExtendModel
	{
	
	}
}