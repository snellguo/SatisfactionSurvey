using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartFramwork.Domain.Manage.Entities
{
	/// <summary>
	/// 用户表
	/// 用户表
	/// </summary>
	public class UserEntity
	{
		public const string TableName = "base_user";

		/// <summary>
		/// 编号
		/// 用户ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// GUID
		/// GUID
		/// </summary>
		public string  guid { get; set; }

		/// <summary>
		/// 组织机构
		/// 组织机构
		/// </summary>
		public int? organization_id { get; set; } = 1;

		/// <summary>
		/// 部门主键
		/// 部门主键
		/// </summary>
		public int? drpartment_id { get; set; }

		/// <summary>
		/// 用户名
		/// 用户登录系统的账户
		/// </summary>
		public string username { get; set; }

		/// <summary>
		/// 用户密码
		/// 用户密码，MD5码   MD5=MD5(用户名+密码)
		/// </summary>
		public string password { get; set; }

		/// <summary>
		/// 姓名
		/// 姓名
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 英文名称
		/// 英文名称
		/// </summary>
		public string english_name { get; set; }

		/// <summary>
		/// 别名
		/// 别名
		/// </summary>
		public string alias { get; set; }

		/// <summary>
		/// 性别
		/// 性别  1 男  0女  关联字典表
		/// </summary>
		public int? gender { get; set; } = 0;

		/// <summary>
		/// 生日
		/// 生日
		/// </summary>
		public DateTime? birthday { get; set; }

		/// <summary>
		/// QQ
		/// QQ
		/// </summary>
		public string QQ { get; set; }

		/// <summary>
		/// 注册时间
		/// 注册时间
		/// </summary>
		public DateTime? register_date { get; set; }

		/// <summary>
		/// 用户头像
		/// 用户头像
		/// </summary>
		public string photo { get; set; }

		/// <summary>
		/// 职位
		/// 岗位
		/// </summary>
		public string post { get; set; }

		/// <summary>
		/// 邮箱
		/// 邮箱
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// 手机号码
		/// 手机号码
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 座机
		/// 座机
		/// </summary>
		public string  landline { get; set; }

		/// <summary>
		/// 办公电话
		/// 公司电话
		/// </summary>
		public string office_phone { get; set; }

		/// <summary>
		/// 家庭电话
		/// 家庭电话
		/// </summary>
		public string home_phone { get; set; }

		/// <summary>
		/// 分机号
		/// 分机
		/// </summary>
		public string ext { get; set; }

		/// <summary>
		/// 上次登录时间
		/// 上次登录时间
		/// </summary>
		public DateTime? last_time { get; set; }

		/// <summary>
		/// 上次登录IP
		/// 上次登录IP
		/// </summary>
		public string last_ip { get; set; }

		/// <summary>
		/// 系统标识
		/// 1普通用户   0系统用户（不可删除）
		/// </summary>
		public int? system_flag { get; set; } = 0;

		/// <summary>
		/// 状态
		/// 0离职1在职
		/// </summary>
		public byte? status { get; set; } = 1;

		/// <summary>
		/// 是否在线
		/// 0离线1在线
		/// </summary>
		public int? is_online { get; set; } = 0;

		/// <summary>
		/// 是否删除
		/// 删除标记
		/// </summary>
		public byte? is_delete { get; set; } = 0;

		/// <summary>
		/// 是否启用
		/// 0禁用  1启用
		/// </summary>
		public int? activate { get; set; } = 0;

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
		/// 拼音
		/// </summary>
		public string pinyin { get; set; }

		/// <summary>
		/// 拼音首字母
		/// </summary>
		public string py { get; set; }

		public int? is_top { get; set; }

		public DateTime? top_time { get; set; }
	}
}