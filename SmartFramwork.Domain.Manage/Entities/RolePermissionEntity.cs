using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 角色权限关系表
	/// 角色权限关联列表
	/// </summary>
	public class RolePermissionEntity
	{
		public const string TableName = "base_role_permission";

		/// <summary>
		/// 编号
		/// 
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 角色主键
		/// 角色主键
		/// </summary>
		public int role_id { get; set; }

		/// <summary>
		/// 权限主键
		/// 权限主键
		/// </summary>
		public int permission_id { get; set; }

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