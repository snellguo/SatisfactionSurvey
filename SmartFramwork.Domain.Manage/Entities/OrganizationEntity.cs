using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 组织机构表
	/// 公司组织机构表
	/// </summary>
	public class OrganizationEntity
	{
		public const string TableName = "base_organization";
		public const string Id = "id";

		/// <summary>
		/// ID
		/// 
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// 应用ID
		/// 应用的ID
		/// </summary>
		public int? app_id { get; set; } = 0;

		/// <summary>
		/// 机构名称
		/// 机构名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 机构代码
		/// 机构代码
		/// </summary>
		public string code { get; set; }

		/// <summary>
		/// 描述
		/// 描述
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// 上级机构
		/// 上级机构      -1代表根节点
		/// </summary>
		public int? parent_id { get; set; } = 0;

		/// <summary>
		/// 级别
		/// 总公司，分公司，网点
		/// </summary>
		public int? level { get; set; }

		/// <summary>
		/// 类型
		/// 
		/// </summary>
		public int? type { get; set; } = 0;

		/// <summary>
		/// 备注
		/// 备注
		/// </summary>
		public string remarks { get; set; }

		/// <summary>
		/// 创建用户
		/// 创建用户ID
		/// </summary>
		public int? creator_id { get; set; } = 0;

		/// <summary>
		/// 创建用户名
		/// 用户名称
		/// </summary>
		public string creator_name { get; set; }

		/// <summary>
		/// 创建时间
		/// 创建时间
		/// </summary>
		public DateTime? creation_date { get; set; }

		/// <summary>
		/// 修改用户
		/// 修改用户ID
		/// </summary>
		public int? modifier_id { get; set; } = 0;

		/// <summary>
		/// 修改用户名
		/// 用户名称
		/// </summary>
		public string modifier_name { get; set; }

		/// <summary>
		/// 修改时间
		/// 修改时间
		/// </summary>
		public DateTime? modification_date { get; set; }
        /// <summary>
		/// CTI服务器
		/// CTI服务器
		/// </summary>
		public int? cti_services { get; set; }
    }
}