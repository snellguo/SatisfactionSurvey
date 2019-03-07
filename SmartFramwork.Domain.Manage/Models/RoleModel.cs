using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 角色表
	/// 角色表
	/// </summary>
	public class RoleModel
	{
        #region customer 自定义
        public string OrgName { get; set; }
        #endregion

        /// <summary>
        /// 编号
        /// 角色ID
        /// </summary>
        [Display(Name = "Manage_RoleModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 系统ID
		/// 
		/// </summary>
		[Display(Name = "Manage_RoleModel_AppID")]
		public int? AppID { get; set; }

		/// <summary>
		/// 机构ID
		/// 机构主键
		/// </summary>
        [Display(Name = "Manage_RoleModel_OrganizationID")]
		public int? OrganizationID { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		[StringLength(100, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Required(ErrorMessage = "Required_ErrorMessage")]
		[Display(Name = "Manage_RoleModel_Name")]
		public string Name  { get; set; } = "";

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		[StringLength(500, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_RoleModel_Description")]
		public string Description { get; set; }

		/// <summary>
		/// 系统标识
		/// 0系统内置（不可删除）1自定义角色   2普通角色
		/// </summary>
		[Display(Name = "Manage_RoleModel_SystemFlag")]
		public int? SystemFlag { get; set; } = 0;

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_RoleModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_RoleModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_RoleModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_RoleModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_RoleModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_RoleModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

	}
}