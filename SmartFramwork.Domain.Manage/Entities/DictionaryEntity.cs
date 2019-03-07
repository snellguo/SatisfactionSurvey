using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 字典表
	/// 
	/// </summary>
	public class DictionaryEntity
	{
		public const string TableName = "base_dictionary";

		/// <summary>
		/// 编号
		/// 编号ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 字典代码
		/// 字典代码
		/// </summary>
		public string code { get; set; }

		/// <summary>
		/// 短名称
		/// 短名称
		/// </summary>
		public string short_name { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// 父级编号
		/// 父级编号
		/// </summary>
		public int? parent_id { get; set; }

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		public int? creator_id { get; set; }

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		public string creator_name { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		public DateTime? creation_date { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		public int? modifier_id { get; set; }

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		public string modifier_name { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		public DateTime? modification_date { get; set; }

	}
}