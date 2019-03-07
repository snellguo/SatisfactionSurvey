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
    public interface IOrganizationService:IBaseService<OrganizationEntity>
    {
        int GetIdByName(string name);   
        void AddChildNode(int id, OrganizationModel model);
        void AddSibshipNode(int id, OrganizationModel model);
        void Create(OrganizationModel model);
        bool Dels(string ids);
        void Edit(OrganizationModel model);
        IList<OrganizationModel> GetByAllList();
        IEnumerable<int> getChildById(int id);
        IList<OrganizationModel> GetChildListByID(int id);
        OrganizationEntity GetEntityByModel(OrganizationModel model);
        OrganizationModel GetModelByEntity(OrganizationEntity entity);
        OrganizationModel GetModelByID(int id);
        OrganizationModel GetModelByID(params object[] keyValues);
        IList<OrganizationModel> GetModelListByEntity<Model, Entity>(IList<Entity> entities, Model model);
        string GetNameById(int id);
        PageResultModel GetPageList(JqGridModel model);
        string GetPathNameByID(int id);
        void TrimOrgCode(int id);
        IList<OrganizationModel> GetByListExcludeParent();
    }
}
