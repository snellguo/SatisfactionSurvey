using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 用户表
	/// 用户表
	/// </summary>
	public partial class UserModel
    {
        /// <summary>
        /// 编号
        /// 用户ID
        /// </summary>
        [Display(Name = "Manage_UserModel_ID")]
        public int ID { get; set; }

        /// <summary>
        /// GUID
        /// GUID
        /// </summary>
        [Display(Name = "Manage_UserModel_Guid")]
        public string Guid { get; set; }

        /// <summary>
        /// 组织机构
        /// 组织机构
        /// </summary>
        [Required(ErrorMessage = "Required_ErrorMessage")]
        [Display(Name = "Manage_UserModel_OrganizationID")]
        public int? OrganizationID { get; set; }// = 1;

        /// <summary>
        /// 部门主键
        /// 部门主键
        /// </summary>
        [Display(Name = "Manage_UserModel_DrpartmentID")]
        public int? DrpartmentID { get; set; }

        /// <summary>
        /// 用户名
        /// 用户登录系统的账户
        /// </summary>
        [StringLength(20, MinimumLength = 2, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Username")]
        [Required(ErrorMessage = "Required_ErrorMessage")]
        public string Username { get; set; }

        /// <summary>
        /// 用户密码
        /// 用户密码，MD5码   MD5=MD5(用户名+密码)
        /// </summary>
        [StringLength(32, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Password")]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// 姓名
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Name")]
        [Required(ErrorMessage = "Required_ErrorMessage")]
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// 英文名称
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_EnglishName")]
        public string EnglishName { get; set; }

        /// <summary>
        /// 别名
        /// 别名
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Alias")]
        public string Alias { get; set; }

        /// <summary>
        /// 性别
        /// 性别  1 男  0女  关联字典表
        /// </summary>
        [Display(Name = "Manage_UserModel_Gender")]
        public int? Gender { get; set; } = 0;
        public string GenderName { get; set; }

        /// <summary>
        /// 生日
        /// 生日
        /// </summary>
        [Display(Name = "Manage_UserModel_Birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// QQ
        /// QQ
        /// </summary>
        [StringLength(20, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_QQ")]
        public string QQ { get; set; }

        /// <summary>
        /// 注册时间
        /// 注册时间
        /// </summary>
        [Display(Name = "Manage_UserModel_RegisterDate")]
        public DateTime? RegisterDate { get; set; }

        /// <summary>
        /// 用户头像
        /// 用户头像
        /// </summary>
        [StringLength(255, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Photo")]
        public string Photo { get; set; }

        /// <summary>
        /// 职位
        /// 岗位
        /// </summary>
        [StringLength(20, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Post")]
        public string Post { get; set; }

        /// <summary>
        /// 邮箱
        /// 邮箱
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Email")]
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// 手机号码
        /// </summary>
        [StringLength(20, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 座机
        /// 座机
        /// </summary>
        [Display(Name = "Manage_UserModel_Landline")]
        public string Landline { get; set; }

        /// <summary>
        /// 办公电话
        /// 公司电话
        /// </summary>
        [StringLength(20, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_OfficePhone")]
        public string OfficePhone { get; set; }

        /// <summary>
        /// 家庭电话
        /// 家庭电话
        /// </summary>
        [StringLength(20, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_HomePhone")]
        public string HomePhone { get; set; }

        /// <summary>
        /// 分机号
        /// 分机
        /// </summary>
        [Required(ErrorMessage = "Required_ErrorMessage")]
        [Display(Name = "Manage_UserModel_Ext")]
        public string Ext { get; set; }

        /// <summary>
        /// 上次登录时间
        /// 上次登录时间
        /// </summary>
        [Display(Name = "Manage_UserModel_LastTime")]
        public DateTime? LastTime { get; set; }

        /// <summary>
        /// 上次登录IP
        /// 上次登录IP
        /// </summary>
        [StringLength(20, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_LastIp")]
        public string LastIp { get; set; }

        /// <summary>
        /// 系统标识
        /// 1普通用户   0系统用户（不可删除）
        /// </summary>
        [Display(Name = "Manage_UserModel_SystemFlag")]
        public int? SystemFlag { get; set; } = 0;

        /// <summary>
        /// 状态
        /// 0离职1在职
        /// </summary>
        [Display(Name = "Manage_UserModel_Status")]
        public byte? Status { get; set; } = 1;
        public string StatusName { get; set; }

        /// <summary>
        /// 是否在线
        /// 0离线1在线
        /// </summary>
        [Display(Name = "Manage_UserModel_IsOnline")]
        public int? IsOnline { get; set; } = 0;

        /// <summary>
        /// 是否删除
        /// 删除标记
        /// </summary>
        [Display(Name = "Manage_UserModel_IsDelete")]
        public byte? IsDelete { get; set; } = 0;

        /// <summary>
        /// 是否启用
        /// 0禁用  1启用
        /// </summary>
        [Display(Name = "Manage_UserModel_Activate")]
        public int? Activate { get; set; }// = 0;

        /// <summary>
        /// 创建用户
        /// 创建用户ID
        /// </summary>
        [Display(Name = "Manage_UserModel_CreatorID")]
        public int? CreatorID { get; set; } = 0;

        /// <summary>
        /// 创建用户名
        /// 用户名称
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_CreatorName")]
        public string CreatorName { get; set; }

        /// <summary>
        /// 创建时间
        /// 创建时间
        /// </summary>
        [Display(Name = "Manage_UserModel_CreationDate")]
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// 修改用户
        /// 修改用户ID
        /// </summary>
        [Display(Name = "Manage_UserModel_ModifierID")]
        public int? ModifierID { get; set; } = 0;

        /// <summary>
        /// 修改用户名
        /// 用户名称
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_ModifierName")]
        public string ModifierName { get; set; }

        /// <summary>
        /// 修改时间
        /// 修改时间
        /// </summary>
        [Display(Name = "Manage_UserModel_ModificationDate")]
        public DateTime? ModificationDate { get; set; }

        /// <summary>
        /// 修改用户名
        /// 用户名称
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_PinYin")]
        public string PinYin { get; set; }

        /// <summary>
        /// 修改用户名
        /// 用户名称
        /// </summary>
        [StringLength(50, MinimumLength = 0, ErrorMessage = "StringLength_ErrorMessage")]
        [Display(Name = "Manage_UserModel_PY")]
        public string PY { get; set; }
    }

    public partial class UserModel {
        /// <summary>
        /// 主键
        /// </summary>
        public const string PK = "id";
        [Required(ErrorMessage = "Required_ErrorMessage")]
        [Display(Name = "Manage_UserModel_OrganizationID")]
        public string OrganizationName { get; set; }
        public string DrpartmentName { get; set; }
        public IList<int?> Roles { get; set; }
        /// <summary>
        /// 图片文件
        /// </summary>
        public IFormFile Files { get; set; }
    }
}