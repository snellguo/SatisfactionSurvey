using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SmartFramwork.Domain.Manage.Models
{
    /// <summary>
    /// 用户注册模型
    /// </summary>
    public class UserChangePasswordModel
    {
        public int userid { get; set; }

        public string  login_name { get; set; }

        [Required(ErrorMessage = "Required_ErrorMessage")]
        [StringLength(20,ErrorMessage = "StringLength_ErrorMessage")]
        [Remote("checkOldPassword", "User", ErrorMessage = "原始密码不正确!", AdditionalFields = "userid")]
        public string old_password { get; set; }

        [Required(ErrorMessage = "Required_ErrorMessage")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "StringLength_ErrorMessage")]
        public string password { get; set; }

        [Required(ErrorMessage = "Required_ErrorMessage")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "StringLength_ErrorMessage")]
        public string password2 { get; set; }
       
    }
}
