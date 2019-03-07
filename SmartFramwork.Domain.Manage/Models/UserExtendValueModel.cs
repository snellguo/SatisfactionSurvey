using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 用户扩展值
	/// 
	/// </summary>
	public partial class UserExtendValueModel
	{
		/// <summary>
		/// 编号
		/// 
		/// </summary>
		[Display(Name = "Manage_UserExtendValueModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 用户ID
		/// 
		/// </summary>
		[Display(Name = "Manage_UserExtendValueModel_UserID")]
		public int? UserID { get; set; }

		/// <summary>
		/// 扩展字段ID
		/// 
		/// </summary>
		[Display(Name = "Manage_UserExtendValueModel_ExtendID")]
		public int? ExtendID { get; set; }

		/// <summary>
		/// 扩展字段名称
		/// 
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_UserExtendValueModel_ExtendName")]
		public string ExtendName { get; set; }

		/// <summary>
		/// 扩展值
		/// 
		/// </summary>
		[StringLength(100, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_UserExtendValueModel_Value")]
		public string Value { get; set; }

	}

	public partial class UserExtendValueModel
	{
	
	}
}