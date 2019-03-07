using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 用户关系角色表
	/// 
	/// </summary>
	public class UserRoleModel
	{
		/// <summary>
		/// 编号
		/// 编号ID
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 系统ID
		/// 系统ID
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_AppID")]
		public int? AppID { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构ID
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_OrganizationID")]
		public int? OrganizationID { get; set; }

		/// <summary>
		/// 用户ID
		/// 用户ID
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_UserID")]
		public int? UserID { get; set; } = 0;

		/// <summary>
		/// 角色ID
		/// 角色ID
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_RoleID")]
		public int? RoleID { get; set; } = 0;

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_UserRoleModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_UserRoleModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_UserRoleModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

	}
}