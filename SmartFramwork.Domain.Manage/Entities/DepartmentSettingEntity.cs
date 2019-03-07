using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 部门配置
	/// 
	/// </summary>
	public class DepartmentSettingEntity
	{
		public const string TableName = "base_department_setting";

		/// <summary>
		/// 编号
		/// 
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 机构/公司
		/// 
		/// </summary>
		public int? organization_id { get; set; }

		/// <summary>
		/// 类型
		/// 1部门2成员
		/// </summary>
		public int? type { get; set; }

		/// <summary>
		/// 值
		/// 
		/// </summary>
		public int? value { get; set; }


		/// <summary>
		/// 代码
		/// 1敏感11白名单，2隐藏22可以查看，3限制33额外
		/// </summary>
		public int? code { get; set; }

	}
}