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
	public interface IPermissionService
    {
        void Create(PermissionModel model);
        void Edit(PermissionModel model);
        PermissionModel GetModelByID(params object[] keyValues);
        PageResultModel GetPageList(JqGridModel model);
        IList<PermissionModel> GetPermissionByAllAndForChecked(int roleid);
        IList<PermissionModel> GetPermissionByRole(IList<RoleModel> role);
        IList<PermissionInfo> GetPermissionByUserID(int id);
    }
}
