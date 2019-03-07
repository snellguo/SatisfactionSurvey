using Microsoft.Extensions.Logging;
using SmartFramwork.Core.Service;
using SmartFramwork.Core.Utils;
using SmartFramwork.Domain.Manage.Entities;
using SmartFramwork.Domain.Manage.Models;
using SmartFramwork.Domain.Manage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SmartFramwork.Web.Models;
using SmartFramwork.Core;
using SmartFramwork.Web.Utils;
using Microsoft.EntityFrameworkCore;
using SmartAddressBook.General.Extension;

namespace SmartFramwork.Domain.Manage.ServiceImpl
{
	public class OrganizationService : BaseService<OrganizationEntity>, IOrganizationService
    {
		private readonly ILogger<OrganizationService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<OrganizationService>>();

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<OrganizationEntity>()
				{
					pageIndex = model.page,
					pageSize = model.rows,
					Where = n => true,
					orderBy = model.sidx,
					isAsc = model.sord == "asc",
				};

				if (model.search)
				{
					foreach (var r in model.filters.rules)
					{
						if (r.field == "keyValue" && !string.IsNullOrWhiteSpace(r.data))
						{
							//pageExp.Where = pageExp.Where.And(n => n.name.Contains(r.data));
						}

					}
				}

				var result = new PageResultModel();

				var list = FindByPage(pageExp.Where, pageExp.orderBy, pageExp.isAsc, pageExp.pageIndex, pageExp.pageSize, out pageExp.total);

				//转换对象
				result.rows = (from entity in list
							   select new OrganizationModel
							   {
									ID = entity.id,
									AppID = entity.app_id,
									Name = entity.name,
									Code = entity.code,
									Description = entity.description,
									ParentID = entity.parent_id,
									Level = entity.level,
									Type = entity.type,
									Remarks = entity.remarks,
									CreatorID = entity.creator_id,
									CreatorName = entity.creator_name,
									CreationDate = entity.creation_date,
									ModifierID = entity.modifier_id,
									ModifierName = entity.modifier_name,
									ModificationDate = entity.modification_date,
                                    CtiServices = entity.cti_services,
                               }).ToList();


				result.pageIndex = pageExp.pageIndex;
				result.records = pageExp.total;
				result.total = Convert.ToInt32(Math.Ceiling((double)pageExp.total / (double)pageExp.pageSize));

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 新建组织机构表
		public void Create(OrganizationModel model)
		{
			try
			{
				var entity = new OrganizationEntity();				
				entity.id = GetUid(OrganizationEntity.TableName).ToInt32();
				entity.app_id = model.AppID;
				entity.name = model.Name;
				entity.code = model.Code;
				entity.description = model.Description;
				entity.parent_id = model.ParentID;
				entity.level = model.Level;
				entity.type = model.Type;
				entity.remarks = model.Remarks;
				entity.creator_id = model.CreatorID;
				entity.creator_name = model.CreatorName;
				entity.creation_date = model.CreationDate;
				entity.modifier_id = model.ModifierID;
				entity.modifier_name = model.ModifierName;
				entity.modification_date = model.ModificationDate;
                entity.cti_services = model.CtiServices;

                Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取组织机构表
		public OrganizationModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new OrganizationModel()
				{
					ID = entity.id,
					AppID = entity.app_id,
					Name = entity.name,
					Code = entity.code,
					Description = entity.description,
					ParentID = entity.parent_id,
					Level = entity.level,
					Type = entity.type,
					Remarks = entity.remarks,
					CreatorID = entity.creator_id,
					CreatorName = entity.creator_name,
					CreationDate = entity.creation_date,
					ModifierID = entity.modifier_id,
					ModifierName = entity.modifier_name,
					ModificationDate = entity.modification_date,
                    CtiServices = entity.cti_services,
                };
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改组织机构表
		public void Edit(OrganizationModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.app_id = model.AppID;
			entity.name = model.Name;
			entity.code = model.Code;
			entity.description = model.Description;
			entity.parent_id = model.ParentID;
			entity.level = model.Level;
			entity.type = model.Type;
			entity.remarks = model.Remarks;
			entity.creator_id = model.CreatorID;
			entity.creator_name = model.CreatorName;
			entity.creation_date = model.CreationDate;
			entity.modifier_id = model.ModifierID;
			entity.modifier_name = model.ModifierName;
			entity.modification_date = model.ModificationDate;
            entity.cti_services = model.CtiServices;

            Edit(entity);
		}
        #endregion

        public OrganizationModel GetModelByEntity(OrganizationEntity entity)
        {
            return new OrganizationModel()
            {
                ID = entity.id,
                AppID = entity.app_id,
                Name = entity.name,
                Code = entity.code,
                Description = entity.description,
                ParentID = entity.parent_id,
                Level = entity.level,
                Type = entity.type,
                Remarks = entity.remarks,
                CreatorID = entity.creator_id,
                CreatorName = entity.creator_name,
                CreationDate = entity.creation_date,
                ModifierID = entity.modifier_id,
                ModifierName = entity.modifier_name,
                ModificationDate = entity.modification_date,
                CtiServices = entity.cti_services,

        };
        }

        public OrganizationEntity GetEntityByModel(OrganizationModel model)
        {
            return new OrganizationEntity()
            {
                id = model.ID,
                app_id = model.AppID,
                name = model.Name,
                code = model.Code,
                description = model.Description,
                parent_id = model.ParentID,
                level = model.Level,
                type = model.Type,
                remarks = model.Remarks,
                creator_id = model.CreatorID,
                creator_name = model.CreatorName,
                creation_date = model.CreationDate,
                modifier_id = model.ModifierID,
                modifier_name = model.ModifierName,
                modification_date = model.ModificationDate,
                cti_services = model.CtiServices,
            };
        }
        public string GetNameById(int id)
        {
            try
            {
                var org = FindByKey(id);
                return org.name;

            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return "";
            }
        }
        public OrganizationModel GetModelByID(int id)
        {
            return GetModelByEntity(FindByKey(id));
        }
        public void AddSibshipNode(int id, OrganizationModel model)
        {
            var entity = FindByKey(id);
            model.ID = int.Parse(GetUid(OrganizationEntity.TableName).ToString());
            model.ParentID = entity.parent_id;
            model.Code = entity.code.Substring(0, entity.code.Length - 3) + (FindByWhere(n => n.parent_id == entity.parent_id, "id", true).Count + 1).ToString("000");
            //model.public_flag = 1;

            Create(model);
        }
        //public int Create(OrganizationModel model)
        //{
        //    return Create(GetEntityByModel(model));
        //}

        //public int Edit(OrganizationModel model)
        //{
        //    return Edit(GetEntityByModel(model));
        //}
        public IList<OrganizationModel> GetByAllList()
        {
            return GetModelListByEntity(FindByAll()
                , new OrganizationModel());
        }
        public IList<OrganizationModel> GetByListExcludeParent()
        {
            //获取登陆用户机构
            var orgid = SessionUtil.GetUserInfo().OrgID;
            //获取机构code
            var code = GetModelByID(orgid).Code;
            //通过code获取本机构及子机构
            var list = FindByWhere(n => n.code.IndexOf(code) == 0,OrganizationEntity.Id,true);
            return GetModelListByEntity(list
               , new OrganizationModel());
        }
        public IList<OrganizationModel> GetModelListByEntity<Model, Entity>
            (IList<Entity> entities, Model model)
        {
            IList<OrganizationModel> modelList = new List<OrganizationModel>();

            foreach (Entity entity in entities)
            {
                modelList.Add(GetModelByEntity(entity as OrganizationEntity));
            }
            return modelList;
        }
        public IList<OrganizationModel> GetChildListByID(int id)
        {
            var entity = FindByKey(id);

            if (entity == null)
                return new List<OrganizationModel>();

            var allList = FindByWhere(n => n.code.StartsWith(entity.code), "id", false);

            return GetModelListByEntity(allList, new OrganizationModel());
        }
        public string GetPathNameByID(int id)
        {
            string ret = "";
            var entity = FindByKey(id);
            var OrgCode = entity.code;
            var list = new List<string>();
            for (int i = 1; i <= OrgCode.Length / 3; i++)
            {
                list.Add(OrgCode.Substring(0, i * 3));
            }

            var mlist = FindByWhere(n => list.Contains(n.code), "Id", true);
            foreach (var item in mlist)
            {
                ret += "/" + item.name;
            }

            return ret;
        }
        public int GetIdByName(string name)
        {
            var list = FindByWhere(n => n.name == name, "id", true);
            if (list.Count > 0)
                return list.First().id;
            else
                return 0;
        }
        //public PageResultModel GetPageList(JqGridModel jmodel)
        //{
        //    var pageExp = new PageExpression<OrganizationEntity>()
        //    {
        //        pageIndex = jmodel.page,
        //        pageSize = jmodel.rows,
        //        Where = n => true,
        //        orderBy = model.sidx,
        //        isAsc = false,
        //    };

        //    pageExp.Where = pageExp.Where.And(n => n.Parent_id == -1);

        //    if (jmodel.search)
        //    {
        //        foreach (var r in jmodel.filters.rules)
        //        {
        //            if (r.field == "keyValue")
        //            {
        //                if (!string.IsNullOrWhiteSpace(r.data))
        //                {
        //                    pageExp.Where = pageExp.Where.And(n => n.Name.Contains(r.data));
        //                }
        //            }
        //        }
        //    }



        //    var result = new PageResultModel();

        //    var list = FindByPage(pageExp.Where, pageExp.orderBy, pageExp.isAsc, pageExp.pageIndex, pageExp.pageSize, out pageExp.total);

        //    result.rows = (from entity in list
        //                   select new OrganizationModel
        //                   {
        //                   }).ToList();


        //    result.pageIndex = pageExp.pageIndex;
        //    result.records = pageExp.total;
        //    result.total = Convert.ToInt32(Math.Ceiling((double)pageExp.total / (double)pageExp.pageSize));

        //    return result;
        //}
        public void AddChildNode(int id, OrganizationModel model)
        {
            var entity = FindByKey(id);
            model.ID = int.Parse(GetUid(OrganizationEntity.TableName).ToString());
            model.ParentID = entity.id;
            model.Code = entity.code + (FindByWhere(n => n.parent_id == entity.id, "id", true).Count + 1).ToString("000");
            //model.public_flag = 1;

            Create(model);
        }
        public bool Dels(string ids)
        {
            try
            {
                var list = ids.Split(',');
                foreach (var s in list)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        var clist = GetChildListByID(s.ToInt());
                        foreach (var item in clist)
                        {
                            Delete(item.ID);
                            TrimOrgCode(item.ParentID.ToInt());
                        }
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param OrgName="id">父节点id</param>
        public void TrimOrgCode(int id)
        {
            if (id != -1)
            {
                var pmodel = FindByKey(id);
                if (pmodel == null)
                {
                    return;

                }
                var list = FindByWhere(n => n.parent_id == id, "id", true);
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].code = pmodel.code + (i + 1).ToString("000");
                        Edit(list[i]);
                        TrimOrgCode(list[i].id);

                    }
                }
            }
            else
            {
                var list = FindByWhere(n => n.parent_id == id, "id", true);
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].code = (i + 1).ToString("000");
                        Edit(list[i]);

                    }
                }
            }
        }
        public IEnumerable<int> getChildById(int id)
        {
            string orgCode = FindByKey(id).code;
            return FindByWhere(n => n.code.StartsWith(orgCode)
            , "id", true).Select(n => n.id).ToArray();
        }
    }
}
