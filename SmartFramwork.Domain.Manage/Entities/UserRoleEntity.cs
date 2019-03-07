using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 用户关系角色表
	/// 
	/// </summary>
	public class UserRoleEntity
	{
		public const string TableName = "base_user_role";

		/// <summary>
		/// 编号
		/// 编号ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 系统ID
		/// 系统ID
		/// </summary>
		public int? app_id { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构ID
		/// </summary>
		public int? organization_id { get; set; }

		/// <summary>
		/// 用户ID
		/// 用户ID
		/// </summary>
		public int? user_id { get; set; }

		/// <summary>
		/// 角色ID
		/// 角色ID
		/// </summary>
		public int? role_id { get; set; }

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