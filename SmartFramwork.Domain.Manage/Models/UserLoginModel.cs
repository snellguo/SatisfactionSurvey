using SmartFramwork.Domain.Manage.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartFramwork.Domain.Manage.Models
{
	public class UserLoginModel
	{
		[Required(ErrorMessage = "Manage_UserLoginModel_Name_Required_ErrorMessage")]
		[Display(Name = "Manage_UserLoginModel_Name")]		
		public string UserName { get; set; }

		[Required(ErrorMessage = "{0}为必填项")]
		[StringLength(25, MinimumLength = 4, ErrorMessage = "{0}长度必须{2}-{1}之间!")]
		[Display(Name = "Manage_UserLoginModel_Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Manage_UserLoginModel_Description")]
		public bool RememberMe { get; set; }
	}
}
