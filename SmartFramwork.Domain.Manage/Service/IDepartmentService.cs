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
	public interface IDepartmentService:IBaseService<DepartmentEntity>
	{
		/// <summary>
		/// 获取所有数据
		/// </summary>
		/// <returns></returns>
		IList<DepartmentModel> GetAllList(int orgid);

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
		void Create(DepartmentModel model);

		/// <summary>
		/// 编辑
		/// </summary>
		/// <param name="model">Model</param>
		void Edit(DepartmentModel model);

		/// <summary>
		/// 获取模型
		/// </summary>
		/// <param name="keyValue">主键</param>
		/// <returns>Model</returns>
		DepartmentModel GetModelByID(params object[] keyValues);

		/// <summary>
		/// 移动节点
		/// </summary>
		/// <param name="treeNode">移动的节点</param>
		/// <param name="targetNode">目标节点</param>
		/// <param name="moveType">移动类型</param>
		/// <returns></returns>
		void Drag(int treeNode, int targetNode, string moveType);

		/// <summary>
		/// 获取子部门及部门的成员
		/// </summary>
		/// <param name="depart"></param>
		/// <param name="userid"></param>
		/// <returns></returns>
		DepartAndMemberModel GetDepartAndMember(int depart, int userid);
	}
}
