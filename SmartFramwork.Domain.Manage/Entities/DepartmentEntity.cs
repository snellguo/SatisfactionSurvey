using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 部门
	/// 
	/// </summary>
	public class DepartmentEntity
	{
		public const string TableName = "base_department";

		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构主键
		/// </summary>
		public int? organization_id { get; set; } = 0;

		/// <summary>
		/// 部门名称
		/// 部门名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 部门代码
		/// 部门代码
		/// </summary>
		public string code { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// 上级部门
		/// 上级部门
		/// </summary>
		public int? parent_id { get; set; } = 0;

		/// <summary>
		/// 
		/// </summary>
		public int? sort { get; set; } = 0;

		/// <summary>
		/// 类型
		/// 类型
		/// </summary>
		public int? type { get; set; } = 0;

		/// <summary>
		/// 负责人
		/// 负责人
		/// </summary>
		public string manager { get; set; }

		/// <summary>
		/// 电话
		/// 电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 地址
		/// 地址
		/// </summary>
		public string address { get; set; }

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

		/// <summary>
		/// 拼音
		/// </summary>
		public string pinyin { get; set; }

		/// <summary>
		/// 拼音首字母
		/// </summary>
		public string py { get; set; }

	}
}