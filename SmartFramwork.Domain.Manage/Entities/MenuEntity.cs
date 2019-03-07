using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 系统菜单表
	/// 资源表（菜单）
	/// </summary>
	public class MenuEntity
	{
		public const string TableName = "base_menu";

		/// <summary>
		/// 编号
		/// 菜单ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 应用ID
		/// 应用ID
		/// </summary>
		public int? app_id { get; set; }

		/// <summary>
		/// 菜单名称
		/// 菜单名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// 父id
		/// -1  位root
		/// </summary>
		public int? parent_id { get; set; }

		/// <summary>
		/// 级别
		/// 等级
		/// </summary>
		public int? level { get; set; }

		/// <summary>
		/// 菜单节点
		/// 菜单节点 000-000
		/// </summary>
		public string node { get; set; }

		/// <summary>
		/// URL
		/// 连接url地址
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// 菜单类型
		/// 菜单类型 1 模块2 菜单3按钮
		/// </summary>
		public int? type { get; set; }

		/// <summary>
		/// icon
		/// 菜单的ICON
		/// </summary>
		public string icon { get; set; }

		/// <summary>
		/// 是否启用
		/// 0禁用 1启用
		/// </summary>
		public int? activate { get; set; }

		/// <summary>
		/// 排序
		/// 排序
		/// </summary>
		public int? sort { get; set; }

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