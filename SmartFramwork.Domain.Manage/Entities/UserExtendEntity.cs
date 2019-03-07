using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 员工扩展表
	/// 员工扩展表
	/// </summary>
	public class UserExtendEntity
	{
		public const string TableName = "base_user_extend";

		/// <summary>
		/// 编号
		/// 
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 名称
		/// 
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 字段
		/// 
		/// </summary>
		public string field { get; set; }

		/// <summary>
		/// 类型
		/// 1,系统2自定义
		/// </summary>
		public int? type { get; set; }

		/// <summary>
		/// 是否展示
		/// 1展示0隐藏
		/// </summary>
		public int? is_show { get; set; }

		/// <summary>
		/// 是否敏感数据
		/// 1展示0隐藏
		/// </summary>
		public int? is_sensitive { get; set; }

		/// <summary>
		/// 是否桌面展示
		/// 1展示0隐藏
		/// </summary>
		public int? is_desktop { get; set; }

		/// <summary>
		/// 排序
		/// 
		/// </summary>
		public int? sort { get; set; }

	}
}