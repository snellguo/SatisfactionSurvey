using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 系统菜单表
	/// 资源表（菜单）
	/// </summary>
	public class MenuModel
	{
		/// <summary>
		/// 编号
		/// 菜单ID
		/// </summary>
		[Display(Name = "Manage_MenuModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 应用ID
		/// 应用ID
		/// </summary>
		[Display(Name = "Manage_MenuModel_AppID")]
		public int? AppID { get; set; } = 0;

		/// <summary>
		/// 菜单名称
		/// 菜单名称
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_MenuModel_Name")]
		public string Name { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		[StringLength(255, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_MenuModel_Description")]
		public string Description { get; set; }

		/// <summary>
		/// 父id
		/// -1  位root
		/// </summary>
		[Display(Name = "Manage_MenuModel_ParentID")]
		public int? ParentID { get; set; } = 0;

		/// <summary>
		/// 级别
		/// 等级
		/// </summary>
		[Display(Name = "Manage_MenuModel_Level")]
		public int? Level { get; set; } = 0;

		/// <summary>
		/// 菜单节点
		/// 菜单节点 000-000
		/// </summary>
		[StringLength(60, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_MenuModel_Node")]
		public string Node { get; set; }

		/// <summary>
		/// URL
		/// 连接url地址
		/// </summary>
		[StringLength(255, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_MenuModel_Url")]
		public string Url { get; set; }

		/// <summary>
		/// 菜单类型
		/// 菜单类型 1 模块2 菜单3按钮
		/// </summary>
		[Display(Name = "Manage_MenuModel_Type")]
		public int? Type { get; set; } = 0;

		/// <summary>
		/// icon
		/// 菜单的ICON
		/// </summary>
		[StringLength(255, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_MenuModel_Icon")]
		public string Icon { get; set; }

		/// <summary>
		/// 是否启用
		/// 0禁用 1启用
		/// </summary>
		[Display(Name = "Manage_MenuModel_Activate")]
		public int? Activate { get; set; } = 0;

		/// <summary>
		/// 排序
		/// 排序
		/// </summary>
		[Display(Name = "Manage_MenuModel_Sort")]
		public int? Sort { get; set; }

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_MenuModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_MenuModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_MenuModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_MenuModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_MenuModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_MenuModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

	}
}