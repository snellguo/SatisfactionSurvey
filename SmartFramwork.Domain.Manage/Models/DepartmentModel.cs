using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 部门
	/// 
	/// </summary>
	public class DepartmentModel
	{
		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构主键
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_OrganizationID")]
		public int? OrganizationID { get; set; } = 0;

		/// <summary>
		/// 部门名称
		/// 部门名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_Name")]
		public string Name { get; set; }

		/// <summary>
		/// 部门代码
		/// 部门代码
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_Code")]
		public string Code { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		[StringLength(500, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_Description")]
		public string Description { get; set; }

		/// <summary>
		/// 上级部门
		/// 上级部门
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_ParentID")]
		public int? ParentID { get; set; } = 0;

		/// <summary>
		/// 类型
		/// 类型
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_Type")]
		public int? Type { get; set; } = 0;

		/// <summary>
		/// 负责人
		/// 负责人
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_Manager")]
		public string Manager { get; set; }

		/// <summary>
		/// 电话
		/// 电话
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_Phone")]
		public string Phone { get; set; }

		/// <summary>
		/// 地址
		/// 地址
		/// </summary>
		[StringLength(100, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_Address")]
		public string Address { get; set; }

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DepartmentModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_DepartmentModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

	}
}