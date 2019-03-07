using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 设备信息
	/// 设备信息
	/// </summary>
	public class DeviceEntity
	{
		public const string TableName = "hc_device";

		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// CTI编号
		/// </summary>
		public int? cti_id { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 账户
		/// 账户
		/// </summary>
		public string account { get; set; }

		/// <summary>
		/// 密码
		/// 密码
		/// </summary>
		public string password { get; set; }

		/// <summary>
		/// IP地址
		/// IP地址
		/// </summary>
		public string ip { get; set; }

		/// <summary>
		/// 端口
		/// 端口
		/// </summary>
		public byte? port { get; set; }

		/// <summary>
		/// 型号
		/// 话机的型号
		/// </summary>
		public string model { get; set; }

		/// <summary>
		/// 品牌
		/// ale，yelin等
		/// </summary>
		public string brand { get; set; }

		/// <summary>
		/// 类型
		/// 1话机,2电脑等
		/// </summary>
		public string type { get; set; }

	}
}