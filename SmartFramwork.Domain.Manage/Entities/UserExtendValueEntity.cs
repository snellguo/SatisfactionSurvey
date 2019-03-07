using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 用户扩展值
	/// 
	/// </summary>
	public class UserExtendValueEntity
	{
		public const string TableName = "base_user_extend_value";

		/// <summary>
		/// 编号
		/// 
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 用户ID
		/// 
		/// </summary>
		public int? user_id { get; set; }

		/// <summary>
		/// 扩展字段ID
		/// 
		/// </summary>
		public int? extend_id { get; set; }

		/// <summary>
		/// 扩展字段名称
		/// 
		/// </summary>
		public string extend_name { get; set; }

		/// <summary>
		/// 扩展值
		/// 
		/// </summary>
		public string value { get; set; }

	}
}