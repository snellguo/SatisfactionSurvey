using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 用户注册模型
	/// </summary>
	public class UserRegisterModel
	{
		public int id { get; set; }

		[Required(ErrorMessage = "Required_ErrorMessage!")]
		public int? orgid { get; set; }

		[Required(ErrorMessage = "Required_ErrorMessage")]
		[Display(Name = "Manage_UserLoginModel_Name")]
		//[Remote("checkUserName", "User", ErrorMessage = "用户名称已存在!", AdditionalFields = "userid")]
		public string login_name { get; set; }

		[Required(ErrorMessage = "Required_ErrorMessage")]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "Manage_ErrorMessage_StringLength")]
		[Display(Name = "Manage_UserLoginModel_Password")]
		public string password { get; set; }

		[StringLength(20, ErrorMessage = "姓名的长度不允许超过20位!")]
		public string name { get; set; }
		public int sex { get; set; }


		[RegularExpression(@"^[0-9]*$", ErrorMessage = "请输入数字！")]
		[StringLength(20, ErrorMessage = "电话的长度不允许超过20位!")]
		public string phone { get; set; }
		[RegularExpression(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$", ErrorMessage = "请输入正确的Email格式！")]
		[StringLength(50, ErrorMessage = "邮箱的长度不允许超过50位!")]
		public string email { get; set; }
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "请输入数字！")]
		[StringLength(20, ErrorMessage = "QQ的长度不允许超过20位!")]
		public string QQ { get; set; }
		public DateTime? register_date { get; set; }
		public string photo { get; set; }
		public int system_flag { get; set; }
		public int status { get; set; }
		public int activate { get; set; }
		public DateTime? last_time { get; set; }
		public string last_ip { get; set; }

		[Display(Name = "角色")]
		public IList<int> roles { get; set; }
	}
}