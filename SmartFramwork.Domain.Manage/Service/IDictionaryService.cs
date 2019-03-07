using SmartFramwork.Core.Service;
using SmartFramwork.Domain.Manage.Entities;
using SmartFramwork.Domain.Manage.Models;
using SmartFramwork.Web.Models;

namespace SmartFramwork.Domain.Manage.Service
{
	/// <summary>
	/// 用户
	/// </summary>
	public interface IDictionaryService:IBaseService<DictionaryEntity>
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
		void Create(DictionaryModel model);

		/// <summary>
		/// 编辑
		/// </summary>
		/// <param name="model">Model</param>
		void Edit(DictionaryModel model);

		/// <summary>
		/// 获取模型
		/// </summary>
		/// <param name="keyValue">主键</param>
		/// <returns>Model</returns>
		DictionaryModel GetModelByID(params object[] keyValues);
	}
}
