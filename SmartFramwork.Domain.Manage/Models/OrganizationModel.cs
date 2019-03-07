using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 组织机构表
	/// 公司组织机构表
	/// </summary>
	public class OrganizationModel
	{
       
        /// <summary>
        /// ID
        /// 
        /// </summary>
        [Display(Name = "Manage_OrganizationModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 应用ID
		/// 应用的ID
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_AppID")]
		public int? AppID { get; set; } = 0;

		/// <summary>
		/// 机构名称
		/// 机构名称
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_OrganizationModel_Name")]
		public string Name { get; set; }

		/// <summary>
		/// 机构代码
		/// 机构代码
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_OrganizationModel_Code")]
		public string Code { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		[StringLength(500, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_OrganizationModel_Description")]
		public string Description { get; set; }

		/// <summary>
		/// 上级机构
		/// 上级机构      -1代表根节点
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_ParentID")]
		public int? ParentID { get; set; } = 0;

		/// <summary>
		/// 级别
		/// 总公司，分公司，网点
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_Level")]
		public int? Level { get; set; }

		/// <summary>
		/// 类型
		/// 
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_Type")]
		public int? Type { get; set; } = 0;

		/// <summary>
		/// 备注
		/// 备注
		/// </summary>
		[StringLength(500, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_OrganizationModel_Remarks")]
		public string Remarks { get; set; }

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_OrganizationModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_OrganizationModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }
        /// <summary>
		/// CTI服务器
		/// CTI服务器
		/// </summary>
		[Display(Name = "Manage_OrganizationModel_CtiServices")]
        public int? CtiServices { get; set; }
    }
}