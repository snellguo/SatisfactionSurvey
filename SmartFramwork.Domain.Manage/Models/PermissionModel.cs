using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 操作权限表
	/// 操作权限表
	/// </summary>
	public class PermissionModel
	{
		/// <summary>
		/// 编号ID
		/// 编号ID
		/// </summary>
		[Display(Name = "Manage_PermissionModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// appid
		/// appid
		/// </summary>
		[Display(Name = "Manage_PermissionModel_AppID")]
		public int? AppID { get; set; } = 0;

		/// <summary>
		/// 菜单id
		/// 菜单ID
		/// </summary>
		[Display(Name = "Manage_PermissionModel_MenuID")]
		public int? MenuID { get; set; } = 0;

		/// <summary>
		/// 权限码
		/// 权限码
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(30, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_Code")]
		public string Code { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_Name")]
		public string Name { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_Description")]
		public string Description { get; set; }

		/// <summary>
		/// 父节点
		/// 父节点
		/// </summary>
		[Display(Name = "Manage_PermissionModel_ParentID")]
		public int? ParentID { get; set; } = -1;

		/// <summary>
		/// Icon
		/// Icon
		/// </summary>
		[StringLength(255, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_Icon")]
		public string Icon { get; set; }

		/// <summary>
		/// 类型
		/// 1菜单   2页面   3按钮
		/// </summary>
		[Display(Name = "Manage_PermissionModel_Type")]
		public int? Type { get; set; }

		/// <summary>
		/// 脚本
		/// 脚本
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_Script")]
		public string Script { get; set; }

		/// <summary>
		/// 样式
		/// 样式 CSS
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_Style")]
		public string Style { get; set; }

		/// <summary>
		/// 是否启用
		/// 0禁用1启用
		/// </summary>
		[Display(Name = "Manage_PermissionModel_Activate")]
		public int? Activate { get; set; } = 1;

		/// <summary>
		/// 排序
		/// 排序
		/// </summary>
		[Display(Name = "Manage_PermissionModel_Sort")]
		public int? Sort { get; set; } = 0;

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_PermissionModel_CreatorID")]
		public int? CreatorID { get; set; }

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_PermissionModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_PermissionModel_ModifierID")]
		public int? ModifierID { get; set; }

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_PermissionModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_PermissionModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

        public bool isChecked { get; set; } = true;

    }
}