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


namespace SmartFramwork.Domain.Manage.ServiceImpl
{
	public class DepartmentService : BaseService<DepartmentEntity>, IDepartmentService
	{
		private readonly ILogger<DepartmentService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<DepartmentService>>();


		#region 获取所有数据列表
		public IList<DepartmentModel> GetAllList(int orgid)
		{
			try
			{
				IList<DepartmentEntity> list;
				if (orgid != 0)
				{
					list = FindByWhere(n => n.organization_id == orgid, "sort", true);
				}
				else
				{
					list = FindByWhere(n => true, "sort", true);
				}

				//转换对象
				var result = (from entity in list
							  select new DepartmentModel
							  {
								  ID = entity.id,
								  OrganizationID = entity.organization_id,
								  Name = entity.name,
								  Code = entity.code,
								  Description = entity.description,
								  ParentID = entity.parent_id,
								  Type = entity.type,
								  Manager = entity.manager,
								  Phone = entity.phone,
								  Address = entity.address,
								  CreatorID = entity.creator_id,
								  CreatorName = entity.creator_name,
								  CreationDate = entity.creation_date,
								  ModifierID = entity.modifier_id,
								  ModifierName = entity.modifier_name,
								  ModificationDate = entity.modification_date,
							  }).ToList();

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<DepartmentEntity>()
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
							   select new DepartmentModel
							   {
								   ID = entity.id,
								   OrganizationID = entity.organization_id,
								   Name = entity.name,
								   Code = entity.code,
								   Description = entity.description,
								   ParentID = entity.parent_id,
								   Type = entity.type,
								   Manager = entity.manager,
								   Phone = entity.phone,
								   Address = entity.address,
								   CreatorID = entity.creator_id,
								   CreatorName = entity.creator_name,
								   CreationDate = entity.creation_date,
								   ModifierID = entity.modifier_id,
								   ModifierName = entity.modifier_name,
								   ModificationDate = entity.modification_date,
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

		#region 新建部门
		public void Create(DepartmentModel model)
		{
			try
			{
				var entity = new DepartmentEntity();
				entity.id = GetUid(DepartmentEntity.TableName).ToInt32();
				entity.organization_id = model.OrganizationID;
				entity.name = model.Name;
				entity.code = model.Code;
				entity.description = model.Description;
				entity.parent_id = model.ParentID;
				entity.type = model.Type;
				entity.manager = model.Manager;
				entity.phone = model.Phone;
				entity.address = model.Address;
				entity.creator_id = model.CreatorID;
				entity.creator_name = model.CreatorName;
				entity.creation_date = model.CreationDate;
				entity.modifier_id = model.ModifierID;
				entity.modifier_name = model.ModifierName;
				entity.modification_date = model.ModificationDate;
				try
				{
					entity.pinyin = PinyinUtil.GetPinyin(model.Name);
					entity.py = PinyinUtil.GetFirstPinyin(model.Name);
				}
				catch (Exception ex)
				{
					//不处理异常
				}

				Create(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取部门
		public DepartmentModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);

				return new DepartmentModel()
				{
					ID = entity.id,
					OrganizationID = entity.organization_id,
					Name = entity.name,
					Code = entity.code,
					Description = entity.description,
					ParentID = entity.parent_id,
					Type = entity.type,
					Manager = entity.manager,
					Phone = entity.phone,
					Address = entity.address,
					CreatorID = entity.creator_id,
					CreatorName = entity.creator_name,
					CreationDate = entity.creation_date,
					ModifierID = entity.modifier_id,
					ModifierName = entity.modifier_name,
					ModificationDate = entity.modification_date,
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改部门
		public void Edit(DepartmentModel model)
		{
			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.organization_id = model.OrganizationID;
			entity.name = model.Name;
			entity.code = model.Code;
			entity.description = model.Description;
			entity.parent_id = model.ParentID;
			entity.type = model.Type;
			entity.manager = model.Manager;
			entity.phone = model.Phone;
			entity.address = model.Address;
			entity.creator_id = model.CreatorID;
			entity.creator_name = model.CreatorName;
			entity.creation_date = model.CreationDate;
			entity.modifier_id = model.ModifierID;
			entity.modifier_name = model.ModifierName;
			entity.modification_date = model.ModificationDate;

			Edit(entity);
		}
		#endregion

		#region 拖拽操作
		public void Drag(int treeNode, int targetNode, string moveType)
		{
			try
			{
				var current = FindByKey(treeNode);
				var target = FindByKey(targetNode);

				//"inner"：成为子节点，"prev"：成为同级前一个节点，"next"
				switch (moveType)
				{
					//成为子节点
					case "inner":
						current.parent_id = target.id;

						var nodes = FindByWhere(n => n.parent_id == target.id, "sort", true);
						var sort = 0;

						for (int i = 0; i < nodes.Count; i++)
						{
							var e = FindByKey(nodes[i].id);
							e.sort = sort;
							Edit(e);
							sort += 10;
						}

						current.sort = sort;
						Edit(current);
						break;
					//成为同级前一个节点
					case "prev":
						current.parent_id = target.parent_id;
						var pNodes = FindByWhere(n => n.parent_id == target.parent_id && n.id != current.id, "sort", true);
						var pSort = 0;

						for (int i = 0; i < pNodes.Count; i++)
						{
							if (pNodes[i].id == target.id)
							{
								current.sort = pSort;
								target.sort = pSort += 10;

								Edit(current);
								Edit(target);
							}
							else
							{
								pSort += 10;

								var e = FindByKey(pNodes[i].id);
								e.sort = pSort;
								Edit(e);
							}
						}

						break;
					//成为同级后一个节点
					case "next":
						current.parent_id = target.parent_id;
						var nNodes = FindByWhere(n => n.parent_id == target.parent_id && n.id != current.id, "sort", true);
						var nSort = 0;

						for (int i = 0; i < nNodes.Count; i++)
						{
							if (nNodes[i].id == target.id)
							{
								current.sort = nSort += 10;
								target.sort = nSort;

								Edit(current);
								Edit(target);
							}
							else
							{
								nSort += 10;

								var e = FindByKey(nNodes[i].id);
								e.sort = nSort;
								Edit(e);
							}
						}
						break;
				}


				SortOut(current.parent_id.Value);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		//整理
		private void SortOut(int parent_id)
		{
			//处理变更后的层级
			var temp = "";
			var count = 100;
			var list = FindByWhere(n => n.parent_id == parent_id, "sort", true);
			if (list.Count == 0)
				return;

			if (parent_id == -1)
			{
				temp = "";
			}
			else
			{
				//获取父层级
				var pModel = FindByKey(parent_id);
				temp = pModel.code;
			}

			foreach (var row in list)
			{
				var m = FindByKey(row.id);
				m.code = temp + count;
				Edit(m);
				count += 1;

				SortOut(row.id);
			}
		}

		#endregion

		public DepartAndMemberModel GetDepartAndMember(int depart, int userid)
		{
			try
			{
				var useSvr = GlobalVariable.ServiceProvider.GetService<IUserService>();

				//查询
				var ret = new DepartAndMemberModel();

				ret.CurrentDepart = GetModelByID(depart);

				ret.Depart = (from item in FindByWhere(n => n.parent_id == depart, "sort", true)
							  select new DepartmentModel()
							  {
								  ID = item.id,
								  OrganizationID = item.organization_id,
								  Name = item.name,
								  Code = item.code,
								  Description = item.description,
								  ParentID = item.parent_id,
								  Type = item.type,
								  Manager = item.manager,
								  Phone = item.phone,
								  Address = item.address
							  }
							).ToList();
				ret.Member = useSvr.GetMemberByDepartmentID(depart, 0);

				return ret;

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}

	}
}
