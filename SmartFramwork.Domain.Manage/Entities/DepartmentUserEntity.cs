using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 部门用户关联表
	/// 部门用户关联表
	/// </summary>
	public class DepartmentUserEntity
	{
		public const string TableName = "base_department_user";

		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构ID
		/// </summary>
		public int? organization_id { get; set; }

		/// <summary>
		/// 部门ID
		/// 部门ID
		/// </summary>
		public int? department_id { get; set; }

		/// <summary>
		/// 用户ID
		/// 用户ID
		/// </summary>
		public int? user_id { get; set; }

		/// <summary>
		/// 是否置顶
		/// </summary>
		public byte? is_top { get; set; }
		/// <summary>
		/// 置顶时间   时间越后 优先级越高
		/// </summary>
		public DateTime? top_time { get; set; }
		/// <summary>
		/// 排序   
		/// </summary>
		public int? order { get; set; }


		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		public int? creator_id { get; set; } = 0;

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
		public int? modifier_id { get; set; } = 0;

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