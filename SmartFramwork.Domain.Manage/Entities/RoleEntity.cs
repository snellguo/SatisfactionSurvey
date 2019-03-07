using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 角色表
	/// 角色表
	/// </summary>
	public class RoleEntity
	{
		public const string TableName = "base_role";

		/// <summary>
		/// 编号
		/// 角色ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 系统ID
		/// 
		/// </summary>
		public int? app_id { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构主键
		/// </summary>
		public int? organization_id { get; set; }

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
		/// 系统标识
		/// 0系统内置（不可删除）1自定义角色   2普通角色
		/// </summary>
		public int? system_flag { get; set; }

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