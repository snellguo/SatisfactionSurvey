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
	public interface IDeviceService:IBaseService<DeviceEntity>
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
		void Create(DeviceModel model);

		/// <summary>
		/// 编辑
		/// </summary>
		/// <param name="model">Model</param>
		void Edit(DeviceModel model);

		/// <summary>
		/// 获取模型
		/// </summary>
		/// <param name="keyValue">主键</param>
		/// <returns>Model</returns>
		DeviceModel GetModelByID(params object[] keyValues);

		/// <summary>
		/// 根据类型返回所有的数据
		/// </summary>
		/// <param name="pageIndex">页码</param>
		/// <param name="pageSize">页大小</param>
		/// <param name="ctiid">ctiid</param>
		/// <returns>设备列表</returns>
		object GetListByPage(int pageIndex, int pageSize, int? ctiid);

		/// <summary>
		/// 验证分机号是否存在
		/// </summary>
		/// <param name="name">分机号</param>
		/// <returns>是否 存在</returns>
		bool CheckUnique(string name);
	}
}
