using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 设备类型代码表
	/// 
	/// </summary>
	public class DriveTypeEntity
	{
		public const string TableName = "code_drive_type";

		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 代码值
		/// 代码值
		/// </summary>
		public string code_value { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		public string code_name { get; set; }

	}
}