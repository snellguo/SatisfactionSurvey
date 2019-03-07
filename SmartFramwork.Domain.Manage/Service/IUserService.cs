using Microsoft.AspNetCore.Mvc;
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
    public interface IUserService:IBaseService<UserEntity>
	{
		/// <summary>
		/// 验证用户
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		int CheckUserLogin(UserLoginModel model);

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
        void Create(UserModel model);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">Model</param>
        void Edit(UserModel model);

        /// <summary>
        /// 获取模型
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns>Model</returns>
        UserModel GetModelByID(params object[] keyValues);

        /// <summary>
        /// 标记删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int MarkupDelete(int id);

        void ResetPassword(int id);

        int ImportFiles(FilesUploadModel model);


		/// <summary>
		/// 通过部门获取员工
		/// </summary>
		/// <param name="departID"></param>
		/// <param name="fetchchild">是否 获取子部门的数据 1迭代   0获取当前</param>
		/// <returns></returns>
		IList<UserModel> GetMemberByDepartmentID(int departID, int fetchchild);


		string Export(JqGridModel jmodel);

		void SetUserDepart(List<int> uids, List<int> dids,int orgid);
        UserModel GetPeopleByCallNum(string callNum);
    }
}
