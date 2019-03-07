using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 系统模块
	/// 
	/// </summary>
	public class ApplicationModel
	{
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[Display(Name = "Manage_ApplicationModel_ID")]
		public int? ID { get; set; }

		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "ErrorMessage_StringLength")]
		[Display(Name = "Manage_ApplicationModel_Name")]
		public string Name { get; set; }

		[StringLength(20, MinimumLength = 4, ErrorMessage = "ErrorMessage_StringLength")]
		[Display(Name = "Manage_ApplicationModel_Code")]
		public string Code { get; set; }

		[StringLength(20, MinimumLength = 4, ErrorMessage = "ErrorMessage_StringLength")]
		[Display(Name = "Manage_ApplicationModel_Description")]
		public string Description { get; set; }

		[Display(Name = "Manage_ApplicationModel_CreateUserid")]
		public int? CreateUserid { get; set; }

		[StringLength(20, MinimumLength = 4, ErrorMessage = "ErrorMessage_StringLength")]
		[Display(Name = "Manage_ApplicationModel_CreateUsername")]
		public string CreateUsername { get; set; }

		[Display(Name = "Manage_ApplicationModel_CreateDate")]
		public DateTime? CreateDate { get; set; }

		[Display(Name = "Manage_ApplicationModel_UpdateUserid")]
		public int? UpdateUserid { get; set; }

		[StringLength(20, MinimumLength = 4, ErrorMessage = "ErrorMessage_StringLength")]
		[Display(Name = "Manage_ApplicationModel_UpdateUsername")]
		public string UpdateUsername { get; set; }

		[Display(Name = "Manage_ApplicationModel_UpdateDate")]
		public DateTime? UpdateDate { get; set; }

	
	}
}