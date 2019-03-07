using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 设备信息
	/// 设备信息
	/// </summary>
	public class DeviceModel
	{
		/// <summary>
		/// 编号
		/// 编号
		/// </summary>
		[Display(Name = "Manage_DeviceModel_ID")]
		public int ID { get; set; }

		/// <summary>
		/// 名称
		/// 名称
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Required(ErrorMessage = "{0}为必填项")]
		[Display(Name = "Manage_DeviceModel_Name")]
		public string Name { get; set; }

		/// <summary>
		/// 账户
		/// 账户
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DeviceModel_Account")]
		public string Account { get; set; }

		/// <summary>
		/// 密码
		/// 密码
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DeviceModel_Password")]
		public string Password { get; set; }

		/// <summary>
		/// IP地址
		/// IP地址
		/// </summary>
		[StringLength(60, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DeviceModel_Ip")]
		public string Ip { get; set; }

		/// <summary>
		/// 端口
		/// 端口
		/// </summary>
		[Display(Name = "Manage_DeviceModel_Port")]
		public string Port { get; set; }

		/// <summary>
		/// 型号
		/// 话机的型号
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DeviceModel_Model")]
		public string Model { get; set; }

		/// <summary>
		/// 品牌
		/// ale，yelin等
		/// </summary>
		[StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
		[Display(Name = "Manage_DeviceModel_Brand")]
		public string Brand { get; set; }

		/// <summary>
		/// 类型
		/// 1话机,2电脑等
		/// </summary>
		[Display(Name = "Manage_DeviceModel_Type")]
		[Required(ErrorMessage = "{0}为必填项")]
		public string Type { get; set; }

        /// <summary>
		/// 类型
		/// 1话机,2电脑等
		/// </summary>
		[Display(Name = "Manage_DeviceModel_Type")]
        [Required(ErrorMessage = "{0}为必填项")]
        public string TypeName { get; set; }

    }
}