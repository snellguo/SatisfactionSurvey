using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 部门用户关联表
	/// 部门用户关联表
	/// </summary>
	public partial class DepartmentUserModel
	{
		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构ID
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_OrganizationID")]
		public int? OrganizationID { get; set; }

		/// <summary>
		/// 部门ID
		/// 部门ID
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_DepartmentID")]
		public int? DepartmentID { get; set; }

		/// <summary>
		/// 用户ID
		/// 用户ID
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_UserID")]
		public int? UserID { get; set; }

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentUserModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentUserModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_DepartmentUserModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

	}

	public partial class DepartmentUserModel
	{
	
	}
}