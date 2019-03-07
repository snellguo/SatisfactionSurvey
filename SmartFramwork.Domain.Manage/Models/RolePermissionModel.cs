using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 角色权限关系表
	/// 角色权限关联列表
	/// </summary>
	public class RolePermissionModel
	{
		/// <summary>
		/// 编号
		/// 
		/// </summary>
		[Display(Name = "Manage_RolePermissionModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 角色主键
		/// 角色主键
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[Display(Name = "Manage_RolePermissionModel_RoleID")]
		public int RoleID { get; set; }

		/// <summary>
		/// 权限主键
		/// 权限主键
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[Display(Name = "Manage_RolePermissionModel_PermissionID")]
		public int PermissionID { get; set; }

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_RolePermissionModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_RolePermissionModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_RolePermissionModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_RolePermissionModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_RolePermissionModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_RolePermissionModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

	}
}