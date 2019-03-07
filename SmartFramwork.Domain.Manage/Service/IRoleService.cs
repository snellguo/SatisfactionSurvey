using SmartFramwork.Core.Service;
using SmartFramwork.Domain.Manage.Entities;
using SmartFramwork.Domain.Manage.Models;
using SmartFramwork.Web.Models;
using System.Collections.Generic;

namespace SmartFramwork.Domain.Manage.Service
{
	/// <summary>
	/// 用户
	/// </summary>
	public interface IRoleService:IBaseService<RoleEntity>
	{
		/// <summary>
		/// 分页列表
		/// </summary>
		/// <param name="page"></param>
		/// <returns></returns>
		PageResultModel GetPageList(JqGridModel model);

		/// <summary>
		/// 创建用户
		/// </summary>
		/// <param name="model">Model</param>
		void Create(RoleModel model);

		/// <summary>
		/// 编辑
		/// </summary>
		/// <param name="model">Model</param>
		void Edit(RoleModel model);

		/// <summary>
		/// 获取模型
		/// </summary>
		/// <param name="keyValue">主键</param>
		/// <returns>Model</returns>
		RoleModel GetModelByID(params object[] keyValues);

        bool GrantRole(int roleid, string pmsnids);
        List<RoleModel> GetList();
        int GetIdByName(string roleName);
    }
}
