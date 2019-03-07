using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 字典表
	/// 
	/// </summary>
	public class DictionaryModel
	{
		/// <summary>
		/// 编号
		/// 编号ID
		/// </summary>
		[Display(Name = "Manage_DictionaryModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 字典代码
		/// 字典代码
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(100, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DictionaryModel_Code")]
		public string Code { get; set; }

		/// <summary>
		/// 短名称
		/// 短名称
		/// </summary>
		[StringLength(100, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DictionaryModel_ShortName")]
		public string ShortName { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(100, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DictionaryModel_Name")]
		public string Name { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		[StringLength(500, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DictionaryModel_Description")]
		public string Description { get; set; }

		/// <summary>
		/// 父级编号
		/// 父级编号
		/// </summary>
		[Display(Name = "Manage_DictionaryModel_ParentID")]
		public int? ParentID { get; set; } = -1;

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		[Display(Name = "Manage_DictionaryModel_CreatorID")]
		public int? CreatorID { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DictionaryModel_CreatorName")]
		public string CreatorName { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		[Display(Name = "Manage_DictionaryModel_CreationDate")]
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		[Display(Name = "Manage_DictionaryModel_ModifierID")]
		public int? ModifierID { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DictionaryModel_ModifierName")]
		public string ModifierName { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		[Display(Name = "Manage_DictionaryModel_ModificationDate")]
		public DateTime? ModificationDate { get; set; }

	}
}