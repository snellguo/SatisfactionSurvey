using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 操作权限表
	/// 操作权限表
	/// </summary>
	public class PermissionEntity
	{
		public const string TableName = "base_permission";

		/// <summary>
		/// 编号ID
		/// 编号ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// appid
		/// appid
		/// </summary>
		public int? app_id { get; set; }

		/// <summary>
		/// 菜单id
		/// 菜单ID
		/// </summary>
		public int? menu_id { get; set; }

		/// <summary>
		/// 权限码
		/// 权限码
		/// </summary>
		public string code { get; set; }

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
		/// 父节点
		/// 父节点
		/// </summary>
		public int? parent_id { get; set; }

		/// <summary>
		/// Icon
		/// Icon
		/// </summary>
		public string icon { get; set; }

		/// <summary>
		/// 类型
		/// 1菜单   2页面   3按钮
		/// </summary>
		public int? type { get; set; }

		/// <summary>
		/// 脚本
		/// 脚本
		/// </summary>
		public string script { get; set; }

		/// <summary>
		/// 样式
		/// 样式 CSS
		/// </summary>
		public string style { get; set; }

		/// <summary>
		/// 是否启用
		/// 0禁用1启用
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