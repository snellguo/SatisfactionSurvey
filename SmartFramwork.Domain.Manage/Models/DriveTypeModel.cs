using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 设备类型代码表
	/// 
	/// </summary>
	public class DriveTypeModel
	{
		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		[Display(Name = "Manage_DriveTypeModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 代码值
		/// 代码值
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DriveTypeModel_CodeValue")]
		public string CodeValue { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DriveTypeModel_CodeName")]
		public string CodeName { get; set; }

	}
}