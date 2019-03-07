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
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Data;
using OfficeOpenXml;
using SmartAddressBook.General.Util;
using System.Collections;
using System.Runtime.InteropServices;

namespace SmartFramwork.Domain.Manage.ServiceImpl
{
	public class UserService : BaseService<UserEntity>, IUserService
	{
		private readonly ILogger<UserService> _logger = GlobalVariable.ServiceProvider.GetService<ILogger<UserService>>();
		private readonly IUserRoleService _userRoleService = GlobalVariable.ServiceProvider.GetService<IUserRoleService>();
		private readonly IOrganizationService _organizationService = GlobalVariable.ServiceProvider.GetService<IOrganizationService>();
		private readonly IDepartmentService _departmentService = GlobalVariable.ServiceProvider.GetService<IDepartmentService>();
		private readonly IDepartmentUserService _departmentUserService = GlobalVariable.ServiceProvider.GetService<IDepartmentUserService>();
		private readonly IRoleService _roleService = GlobalVariable.ServiceProvider.GetService<IRoleService>();
		enum ExcelColumn
		{
			photo = 1,
			roles,
			//guid,
			organization_id,
			//drpartment_id,
			username,
			//password,
			name,
			english_name,
			alias,
			gender,
			birthday,
			QQ,
			//register_date,
			post,
			email,
			phone,
			landline,
			office_phone,
			home_phone,
			ext,
			pinyin,
            py,
			//last_time,
			//last_ip,
			//system_flag,
			//status,
			//is_online,
			//is_delete,
			//activate,
			//creation_date,
			//creator_id,
			//creator_name,
			//modification_date,
			//modifier_id,
			//modifier_name,
		};
		public string Export(JqGridModel jmodel)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic.Add("OrganizationName", "组织机构");
			dic.Add("Username", "用户名");
			dic.Add("Name", "姓名");
			dic.Add("GenderName", "性别");
			dic.Add("Post", "岗位");
			dic.Add("Phone", "手机号码");
			dic.Add("Email", "邮箱");
			dic.Add("OfficePhone", "公司电话");
			dic.Add("HomePhone", "家庭电话");
			dic.Add("Ext", "分机");
			dic.Add("StatusName", "状态");
			#region 完整字典
			/*
             dic.Add("Id","用户ID");
            dic.Add("Guid","");
            dic.Add("Organization_id","组织机构");
            dic.Add("Drpartment_id","部门主键");
            dic.Add("Username","用户登录系统的");
            dic.Add("English_name","");
            dic.Add("Alias","");
            dic.Add("Password","用户密码，MD5");
            dic.Add("Name","姓名");
            dic.Add("Gender","性别1男0");
            dic.Add("Birthday","生日");
            dic.Add("QQ","QQ");
            dic.Add("Register_date","注册时间");
            dic.Add("Photo","用户头像");
            dic.Add("Post","岗位");
            dic.Add("Phone","手机号码");
            dic.Add("Landline","");
            dic.Add("Email","邮箱");
            dic.Add("Office_phone","公司电话");
            dic.Add("Home_phone","家庭电话");
            dic.Add("Ext","分机");
            dic.Add("Last_time","上次登录时间");
            dic.Add("Last_ip","上次登录IP");
            dic.Add("System_flag","1普通用户0");
            dic.Add("Status","0离职1在职");
            dic.Add("Is_online","0离线1在线");
            dic.Add("Is_delete","删除标记");
            dic.Add("Activate","0禁用1启用");
            dic.Add("Creator_id","创建用户ID");
            dic.Add("Creator_name","用户名称");
            dic.Add("Creation_date","创建时间");
            dic.Add("Modifier_id","修改用户ID");
            dic.Add("Modifier_name","用户名称");
            dic.Add("Modification_date","修改时间");
             */
			#endregion


			var pageExp = new PageExpression<UserModel>()
			{
				Where = n => true,
				orderBy = jmodel.sidx,
				isAsc = jmodel.sord == "asc",
			};
			var orgSet = _repo.DbContext.Set<OrganizationEntity>();
			var drptSet = _repo.DbContext.Set<DepartmentEntity>();
			//转换对象
			var query = (from entity in _repo.DbSet
						 join o in orgSet on entity.organization_id
						 equals o.id into uos
						 from uo in uos.DefaultIfEmpty()
						 join d in drptSet on entity.drpartment_id
						 equals d.id into uds
						 from ud in uds.DefaultIfEmpty()
						 select new UserModel
						 {
							 OrganizationName = uo.name,
							 Username = entity.username,
							 Name = entity.name,
							 GenderName = entity.gender == 0 ? "女" : "男",
							 Post = entity.post,
							 Phone = entity.phone,
							 Email = entity.email,
							 OfficePhone = entity.office_phone,
							 HomePhone = entity.home_phone,
							 Ext = entity.ext,
							 StatusName = entity.status == 0 ? "离职" : "在职",
						 });
			IList<UserModel> list = query.Where(pageExp.Where).OrderBy(pageExp.orderBy, pageExp.isAsc).Take(60000).AsNoTracking().ToList();
			string url = "//" + GlobalVariable.HttpContext.Request.Host.ToString();
			url += ExcelUtil.ListToExcel(dic, (IList)list, "User");
			return url;
		}
		private string ConvertObjToStr(object value)
		{
			if (value != null)
				return value.ToString();
			return "";
		}

		#region 获取页面列表
		public PageResultModel GetPageList(JqGridModel model)
		{
			try
			{
				var pageExp = new PageExpression<UserModel>()
				{
					pageIndex = model.page,
					pageSize = model.rows,
					Where = n => true,
					orderBy = model.sidx,
					isAsc = model.sord == "asc",
				};

				pageExp.Where = pageExp.Where.And(n => n.IsDelete == 0);

				//var orgid = SessionUtil.GetUserInfo().OrgID;

				if (model.search)
				{
					foreach (var r in model.filters.rules)
					{
						if (r.field == "keyValue" && !string.IsNullOrWhiteSpace(r.data))
						{
							pageExp.Where = pageExp.Where.And(n => n.Name.Contains(r.data));
							pageExp.Where = pageExp.Where.Or(n => n.Username.Contains(r.data));
						}
						if (r.field == "drpartCode" && !string.IsNullOrWhiteSpace(r.data))
						{
							//处理部门条件的时候 需要同时增加机构的条件
							//var o = (from item in model.filters.rules where item.field == "orgid" select item.data.ToInt32()).FirstOrDefault();

							//var dlist = _departmentService.FindByWhere(n => n.code.StartsWith(r.data) && o == n.organization_id, "sort", true).Select(n => n.id).ToList();
							var dlist = _departmentService.FindByWhere(n => n.code.StartsWith(r.data) , "sort", true).Select(n => n.id).ToList();

							var ulist = _departmentUserService.FindByWhere(n => dlist.Contains(n.department_id.Value), "id", true).Select(n => n.user_id).Distinct().ToList();

							pageExp.Where = pageExp.Where.And(n => ulist.Contains(n.ID));
						}
						if (r.field == "orgid" && !string.IsNullOrWhiteSpace(r.data))
						{
							var orgid2 = r.data.ToInt32();
							pageExp.Where = pageExp.Where.And(n => n.OrganizationID == orgid2);
						}

					}
				}

				var result = new PageResultModel();

				var orgSet = _repo.DbContext.Set<OrganizationEntity>();
				var drptSet = _repo.DbContext.Set<DepartmentEntity>();
				//转换对象
				var query = (from entity in _repo.DbSet
							 join o in orgSet on entity.organization_id
							 equals o.id into uos
							 from uo in uos.DefaultIfEmpty()
							 join d in drptSet on entity.drpartment_id
							 equals d.id into uds
							 from ud in uds.DefaultIfEmpty()
							 select new UserModel
							 {
								 ID = entity.id,
								 OrganizationID = entity.organization_id,
								 OrganizationName = uo.name,
								 DrpartmentID = entity.drpartment_id,
								 DrpartmentName = ud.name,
								 Username = entity.username,
								 Password = entity.password,
								 Name = entity.name,
								 Gender = entity.gender,
								 Birthday = entity.birthday,
								 QQ = entity.QQ,
								 RegisterDate = entity.register_date,
								 Photo = entity.photo,
								 Post = entity.post,
								 Phone = entity.phone,
								 Email = entity.email,
								 OfficePhone = entity.office_phone,
								 HomePhone = entity.home_phone,
								 Ext = entity.ext,
								 LastTime = entity.last_time,
								 LastIp = entity.last_ip,
								 SystemFlag = entity.system_flag,
								 Status = entity.status,
								 IsOnline = entity.is_online,
								 IsDelete = entity.is_delete,
								 Activate = entity.activate,
								 CreatorID = entity.creator_id,
								 CreatorName = entity.creator_name,
								 CreationDate = entity.creation_date,
								 ModifierID = entity.modifier_id,
								 ModifierName = entity.modifier_name,
								 ModificationDate = entity.modification_date,
								 Alias = entity.alias,
								 EnglishName = entity.english_name,
								 Guid = entity.guid,
								 Landline = entity.landline,
                                 PinYin=entity.pinyin,
                                 PY=entity.py
                             });

				result.pageIndex = pageExp.pageIndex;
				result.records = pageExp.total = query.Where(pageExp.Where).Count();
				result.total = Convert.ToInt32(Math.Ceiling((double)pageExp.total / (double)pageExp.pageSize));
				result.rows = query.Where(pageExp.Where).OrderBy(pageExp.orderBy, pageExp.isAsc)
					.Skip(pageExp.pageSize * (pageExp.pageIndex - 1))
					.Take(pageExp.pageSize).ToList();

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 新建用户表
		public void Create(UserModel model)
		{
			if (GlobalVariable.HttpContext.Request.Form.Files.Count > 0)
				model.Files = GlobalVariable.HttpContext.Request.Form.Files[0];
			if (model.Files != null)
			{
				var rootPath = AppDomain.CurrentDomain.BaseDirectory;
                var path = @"/materials/school/photo/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                //判断是否window平台
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    path = @"\materials\school\photo\" + DateTime.Now.ToString("yyyyMMdd") + "\\";


                if (!Directory.Exists(rootPath + path))
				{
					Directory.CreateDirectory(rootPath + path);
				}

				var ext = Path.GetExtension(model.Files.FileName);

				var filename = Guid.NewGuid().ToString().Replace("-", "") + ext;
				var filepath = rootPath + path + filename;

				model.Photo = (path + filename).Replace("\\", "/");

				using (FileStream fs = System.IO.File.Create(filepath))
				{
					model.Files.CopyTo(fs);
					fs.Flush();
				}

			}

			else
			{
				model.Photo = "";
			}

			model.Password = "123456";
			model.Password = CryptoUtil.MD5Encrypt(model.Username.ToLower() + model.Password);
			//model.Activate = 1;
			try
			{
				var entity = new UserEntity();
				entity.id = GetUid(UserEntity.TableName).ToInt32();
				entity.guid = Guid.NewGuid().ToString();
				entity.organization_id = model.OrganizationID;
				entity.drpartment_id = model.DrpartmentID;
				entity.username = model.Username;
				entity.password = model.Password;
				entity.name = model.Name;
				entity.english_name = model.EnglishName;
				entity.alias = model.Alias;
				entity.gender = model.Gender;
				entity.birthday = model.Birthday;
				entity.QQ = model.QQ;
				entity.register_date = model.RegisterDate;
				entity.photo = model.Photo;
				entity.post = model.Post;
				entity.email = model.Email;
				entity.phone = model.Phone;
				entity.landline = model.Landline;
				entity.office_phone = model.OfficePhone;
				entity.home_phone = model.HomePhone;
				entity.ext = model.Ext;
				entity.last_time = model.LastTime;
				entity.last_ip = model.LastIp;
				entity.system_flag = model.SystemFlag;
				entity.status = model.Status;
				entity.is_online = model.IsOnline;
				entity.is_delete = model.IsDelete;
				entity.activate = model.Activate;
				entity.creation_date = DateTime.Now;
				entity.creator_id = SessionUtil.GetUserID().ToInt32();
				entity.creator_name = SessionUtil.GetUserLoginName();
				entity.modification_date = DateTime.Now;
				entity.modifier_id = SessionUtil.GetUserID().ToInt32();
				entity.modifier_name = SessionUtil.GetUserLoginName();

				try
				{
					//汉字转拼音
					entity.pinyin = PinyinUtil.GetPinyin(model.Name);
					entity.py = PinyinUtil.GetFirstPinyin(model.Name);
				}
				catch (Exception ex)
				{
					//不处理异常
				}

				Create(entity);

				_userRoleService.CreateByUserID(entity.id, model.Roles);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 获取用户表
		public UserModel GetModelByID(params object[] keyValues)
		{
			try
			{
				var entity = FindByKey(keyValues);
				var role = (from item in _userRoleService.FindByWhere(n => n.user_id == entity.id, "id", true)
							select item.role_id).ToList();

				return new UserModel()
				{
					ID = entity.id,
					Guid = entity.guid,
					OrganizationID = entity.organization_id,
					OrganizationName = _organizationService.GetNameById(entity.organization_id.ToInt32()),
					DrpartmentID = entity.drpartment_id,
					Username = entity.username,
					Password = entity.password,
					Name = entity.name,
					EnglishName = entity.english_name,
					Alias = entity.alias,
					Gender = entity.gender,
					Birthday = entity.birthday,
					QQ = entity.QQ,
					RegisterDate = entity.register_date,
					Photo = entity.photo,
					Post = entity.post,
					Email = entity.email,
					Phone = entity.phone,
					Landline = entity.landline,
					OfficePhone = entity.office_phone,
					HomePhone = entity.home_phone,
					Ext = entity.ext,
					LastTime = entity.last_time,
					LastIp = entity.last_ip,
					SystemFlag = entity.system_flag,
					Status = entity.status,
					IsOnline = entity.is_online,
					IsDelete = entity.is_delete,
					Activate = entity.activate,
					CreatorID = entity.creator_id,
					CreatorName = entity.creator_name,
					CreationDate = entity.creation_date,
					ModifierID = entity.modifier_id,
					ModifierName = entity.modifier_name,
					ModificationDate = entity.modification_date,
					Roles = role,
                    PinYin=entity.pinyin,
                    PY=entity.py
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw ex;
			}
		}
		#endregion

		#region 修改用户表
		public void Edit(UserModel model)
		{
			if (model.OrganizationID == null)
				model.OrganizationID = 0;

			var entity = FindByKey(model.ID);

			entity.id = model.ID;
			entity.guid = model.Guid;
			entity.organization_id = model.OrganizationID;
			entity.drpartment_id = model.DrpartmentID;
			entity.username = model.Username;
			entity.password = model.Password;
			entity.name = model.Name;
			entity.english_name = model.EnglishName;
			entity.alias = model.Alias;
			entity.gender = model.Gender;
			entity.birthday = model.Birthday;
			entity.QQ = model.QQ;
			entity.register_date = model.RegisterDate;
			entity.photo = SavePhoto(model);
			entity.post = model.Post;
			entity.email = model.Email;
			entity.phone = model.Phone;
			entity.landline = model.Landline;
			entity.office_phone = model.OfficePhone;
			entity.home_phone = model.HomePhone;
			entity.ext = model.Ext;
			entity.last_time = model.LastTime;
			entity.last_ip = model.LastIp;
			entity.system_flag = model.SystemFlag;
			entity.status = model.Status;
			entity.is_online = model.IsOnline;
			entity.is_delete = model.IsDelete;
			entity.activate = model.Activate;
			entity.creator_id = model.CreatorID;
			entity.creator_name = model.CreatorName;
			entity.creation_date = model.CreationDate;
			entity.modification_date = DateTime.Now;
			entity.modifier_id = SessionUtil.GetUserID().ToInt32();
			entity.modifier_name = SessionUtil.GetUserLoginName();
            entity.pinyin = model.PinYin;
            entity.py = model.PY;

			Edit(entity);

			_userRoleService.CreateByUserID(entity.id, model.Roles);
		}
		#endregion

        public string SavePhoto(UserModel model)
        {
            if (GlobalVariable.HttpContext.Request.Form.Files.Count > 0)
                model.Files = GlobalVariable.HttpContext.Request.Form.Files[0];
            if (model.Files != null)
            {
                var rootPath = AppDomain.CurrentDomain.BaseDirectory;
                var path = @"/materials/school/photo/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                //判断是否window平台
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    path = @"\materials\school\photo\" + DateTime.Now.ToString("yyyyMMdd") + "\\";


                if (!Directory.Exists(rootPath + path))
                {
                    Directory.CreateDirectory(rootPath + path);
                }

                var ext = Path.GetExtension(model.Files.FileName);

                var filename = Guid.NewGuid().ToString().Replace("-", "") + ext;
                var filepath = rootPath + path + filename;

                model.Photo = (path + filename).Replace("\\", "/");

                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    model.Files.CopyTo(fs);
                    fs.Flush();
                }

            }
            return model.Photo;
        }

		#region 验证登录
		public int CheckUserLogin(UserLoginModel model)
		{
			IRoleService roleService = GlobalVariable.ServiceProvider.GetService<IRoleService>();
			IPermissionService pmsnService = GlobalVariable.ServiceProvider.GetService<IPermissionService>();
			IMenuService menuService = GlobalVariable.ServiceProvider.GetService<IMenuService>();
			IOrganizationService organizationService = GlobalVariable.ServiceProvider.GetService<IOrganizationService>();


			try
			{
				var password = CryptoUtil.MD5Encrypt(model.UserName.ToLower() + model.Password);

				var userData = _dbSet.Where(n => n.username == model.UserName && n.password == password).SingleOrDefault();

				if (userData != null)
				{
                    //判断离职
                    if (userData.status == 0)
                    {
                        return 3;
                    }
                    if (userData.activate == 1)
					{
                        

                        var userInfo = new UserInfo();
						userInfo.LoginName = userData.username;
						userInfo.OrgID = userData.organization_id.Value;
						try
						{
							userInfo.OrgName = organizationService.FindByKey(userData.organization_id.Value).name;
						}
						catch (Exception ex) { }
						userInfo.UserID = userData.id;
						userInfo.permission = pmsnService.GetPermissionByUserID(userData.id);
						userInfo.menu = menuService.GetMenuByPermission(userInfo.permission);
						userInfo.ExtNo = userData.ext.ToString();

						GlobalVariable.HttpContext.Session.SetObject("UserInfo", userInfo);


						userData.last_time = DateTime.Now;
						userData.last_ip = GlobalVariable.HttpContext.Connection.RemoteIpAddress.ToString();
						Edit(userData);

						return 0;//OK
					}
                    
					return 2; //用户被锁定
				}
				else
				{
					return 1; //用户不存在或密码错误
				}

			}
			catch (Exception e)
			{
				_logger.LogError(e.ToString());
				return -1;
			}
		}
		#endregion

		#region 退出登录
		public void LoginOut()
		{
			SessionUtil.RemoveUserLogin();
		}
		#endregion

		public int MarkupDelete(int id)
		{
			var sql = "update base_user set is_delete = 1 where id = " + id;
			return _repo.DbContext.Database.ExecuteSqlCommand(sql);

		}

		public void ResetPassword(int id)
		{
			UserEntity entity = FindByKey(id);
			entity.password = CryptoUtil.MD5Encrypt(entity.username.ToLower() + "123456");
			Edit(entity);
		}

		#region 导入文件
		/// <summary>
		/// 导入文件
		/// </summary>
		public int ImportFiles(FilesUploadModel model)
		{
			IFormFile fileExcel = model.fileExcel;
			if (fileExcel == null)
				return -1;
			// Excel 文件处理
			if (fileExcel != null)
			{
				if (model.filePhotos != null)
					DataProcess(fileExcel, model.filePhotos.ToList());
				else
					DataProcess(fileExcel, null);
			}
			return 0;
		}
		#endregion

		#region 文件处理 包括 Excel
		private void DataProcess(IFormFile fileExcel, List<IFormFile> filePhotos)
		{
			string guid = Guid.NewGuid().ToString();
			try
			{
				var rootPath = AppDomain.CurrentDomain.BaseDirectory;
				var filepath = rootPath + @"materials\school\temp\";
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                // 保存临时Excel文件
                using (FileStream fs = System.IO.File.Create(filepath + guid + Path.GetExtension(fileExcel.FileName)))
				{
					fileExcel.CopyTo(fs);
					fs.Flush();
				}
				FileInfo file = new FileInfo(filepath + guid + Path.GetExtension(fileExcel.FileName));
				if (file != null)
				{
					using (ExcelPackage package = new ExcelPackage(file))
					{
						ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
						//获取表格的行数
						int rowCount = worksheet.Dimension.Rows;
						DateTime birthdayRow = new DateTime();
						if (rowCount < 2) return;
						for (int row = 2; row <= rowCount; row++)
						{
							//唯一标识
							var unique = worksheet.Cells[row, (int)ExcelColumn.username].Value.ToString();
							string imageStr = "";
							if (worksheet.Cells[row, (int)ExcelColumn.photo].Value != null)
							{
								imageStr = MovePhotoFile2(worksheet.Cells[row, (int)ExcelColumn.photo].Value.ToString(), filePhotos, "");
							}
							if (worksheet.Cells[row, (int)ExcelColumn.birthday].Value != null)
								DateTime.TryParse(worksheet.Cells[row, (int)ExcelColumn.birthday].Value.ToString(), out birthdayRow);

							var entity = FindByWhere(n => n.username == unique, "id", true).FirstOrDefault();
							if (entity == null)
							{
								int? extTemp = null;
								if (worksheet.Cells[row, (int)ExcelColumn.ext].Value != null)
									extTemp = worksheet.Cells[row, (int)ExcelColumn.ext].Value.ToInt32();
								entity = new UserEntity()
								{
									id = GetUid(UserEntity.TableName).ToInt32(),
									photo = imageStr,
									guid = Guid.NewGuid().ToString(),
									organization_id = _organizationService.GetIdByName(ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.organization_id].Value)),
									//drpartment_id = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.drpartment_id].Value),
									username = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.username].Value),
									password = CryptoUtil.MD5Encrypt(ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.username].Value) + "123456"),
									name = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.name].Value),
									english_name = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.english_name].Value),
									alias = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.alias].Value),
									gender = GetCodeByName("gender"
								, ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.gender].Value)),
									birthday = birthdayRow,
									QQ = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.QQ].Value),
									//register_date = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.register_date].Value),
									post = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.post].Value),
									email = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.email].Value),
									phone = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.phone].Value),
									landline = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.landline].Value),
									office_phone = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.office_phone].Value),
									home_phone = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.home_phone].Value),
									pinyin = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.pinyin].Value),
                                    py = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.py].Value),
									ext = extTemp.ToString(),

									//last_time = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.last_time].Value),
									//last_ip = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.last_ip].Value),
									system_flag = 1,
									status = 1,//在职
									//is_online = 0,
									//is_delete = 0,
									activate = 1,
									creation_date = DateTime.Now,
									creator_id = SessionUtil.GetUserID().ToInt32(),
									creator_name = SessionUtil.GetUserLoginName(),
									modification_date = DateTime.Now,
									modifier_id = SessionUtil.GetUserID().ToInt32(),
									modifier_name = SessionUtil.GetUserLoginName(),
								};
								Create(entity);

							}
							else
							{
								//entity.id = GetUid(UserEntity.TableName).ToInt32();
								entity.photo = imageStr;
								//entity.guid = Guid.NewGuid().ToString();imageStrnization_id].Value);
								//entity.drpartment_id = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.drpartment_id].Value);
								entity.username = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.username].Value);
                                entity.password = CryptoUtil.MD5Encrypt(ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.username].Value) + "123456");
								//entity.password = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.password].Value);
								entity.name = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.name].Value);
								entity.english_name = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.english_name].Value);
								entity.alias = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.alias].Value);
								entity.birthday = birthdayRow;
								entity.gender = GetCodeByName("gender", ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.gender].Value));
								entity.QQ = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.QQ].Value);
								//entity.register_date = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.register_date].Value);
								entity.post = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.post].Value);
								entity.email = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.email].Value);
								entity.phone = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.phone].Value);
								entity.landline = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.landline].Value);
								entity.office_phone = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.office_phone].Value);
								entity.home_phone = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.home_phone].Value);
                                entity.pinyin = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.pinyin].Value);
                                entity.py = ConvertObjToStr(worksheet.Cells[row, (int)ExcelColumn.py].Value);
                                if (worksheet.Cells[row, (int)ExcelColumn.ext].Value != null)
									entity.ext = worksheet.Cells[row, (int)ExcelColumn.ext].Value.ToString();
								//entity.last_time = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.last_time].Value);
								//entity.last_ip = ConvertObjToStr(worksheet.Cells[row, (int)UserColumn.last_ip].Value);
								//entity.system_flag = 1;
								//entity.status = 1;//在职
								//entity.is_online = 0;
								//entity.is_delete = 0;
								//entity.activate = 1;
								//entity.creation_date = DateTime.Now;
								//entity.creator_id = SessionUtil.GetUserID().ToInt32();
								//entity.creator_name = SessionUtil.GetUserLoginName();
								entity.modification_date = DateTime.Now;
								entity.modifier_id = SessionUtil.GetUserID().ToInt32();
								entity.modifier_name = SessionUtil.GetUserLoginName();
								Edit(entity);
							}
							if (worksheet.Cells[row, (int)ExcelColumn.roles].Value != null)
							{
								string[] roleNames = worksheet.Cells[row, (int)ExcelColumn.roles].Value.ToString().Split(',');
								IList<int?> Roles = new List<int?>();
								foreach (string roleName in roleNames)
								{
									Roles.Add(_roleService.GetIdByName(roleName));
								}
								_userRoleService.CreateByUserID(entity.id, Roles);
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				_logger.LogError(e.ToString());
				throw e;
			}
			finally
			{
				var rootPath = AppDomain.CurrentDomain.BaseDirectory;
				var filepath = rootPath + @"\materials\school\temp\";
				if (filePhotos != null)
				{
					foreach (var photo in filePhotos)
					{
						if (File.Exists(filepath + photo.FileName))
							File.Delete(filepath + photo.FileName);
					}
				}

				// 删除临时 Excle 文件
				if (File.Exists(filepath + guid + Path.GetExtension(fileExcel.FileName)))
					File.Delete(filepath + guid + Path.GetExtension(fileExcel.FileName));
			}
		}


		#endregion
		private string MovePhotoFile2(string photoName, List<IFormFile> filePhotos, string oldPath)
		{

			if (photoName == "")
				return "";
			var tempPath = @"\materials\school\photo\";
			//判断excel中的照片名，是否存在于（上传的）照片列表
			foreach (IFormFile filePhoto in filePhotos)
			{
				if (filePhoto.FileName.Contains(photoName))
				{
					return FileUtil.AddFile(tempPath, filePhoto, oldPath);
				}
			}
			return "";
		}

		public int GetCodeByName(string filed, string name)
		{
			switch (filed)
			{
				case "gender":
					if (name == "男")
						return 1;
					else
						return 0;
				default:
					return 0;
			}
		}

		#region 通过部门获取员工
		/// <summary>
		/// 通过部门获取员工
		/// </summary>
		/// <param name="departID"></param>
		/// <param name="fetchchild">是否 获取子部门的数据 0 不获取 1获取</param>
		/// <returns></returns>
		public IList<UserModel> GetMemberByDepartmentID(int departID, int fetchchild)
		{
			if (fetchchild == 0)
			{
				var sql = "select u.*  FROM base_user u INNER JOIN base_department_user d ON  u.id=d.user_id and d.department_id=@department_id";

				return (from item in _dbSet.FromSql(sql, _repo.DbContext.CreateParameter("@department_id", departID))
						select new UserModel()
						{
							ID = item.id,
							Guid = item.guid,
							OrganizationID = item.organization_id,
							DrpartmentID = item.drpartment_id,
							Username = item.username,
							Name = item.name,
							EnglishName = item.english_name,
							Alias = item.alias,
							Gender = item.gender,
							Birthday = item.birthday,
							QQ = item.QQ,
							RegisterDate = item.register_date,
							Photo = item.photo,
							Post = item.post,
							Email = item.email,
							Phone = item.phone,
							Landline = item.landline,
							OfficePhone = item.office_phone,
							HomePhone = item.home_phone,
							Ext = item.ext,
							LastTime = item.last_time,
							LastIp = item.last_ip,
							SystemFlag = item.system_flag,
							Status = item.status,
							IsOnline = item.is_online,
							Activate = item.activate
						}).ToList();
			}
			else
			{

			}

			return null;
		}
		#endregion


		#region 设置员工所在部门
		/// <summary>
		/// 设置员工所在部门
		/// </summary>
		/// <param name="uids">员工编号</param>
		/// <param name="dids">部门编号</param>
		/// <param name="orgid">机构</param>
		public void SetUserDepart(List<int> uids, List<int> dids, int orgid)
		{
			foreach (var u in uids)
			{
				_repo.DbContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM base_department_user where user_id = {0}", u));

				foreach (var d in dids)
				{
					_departmentUserService.Create(new DepartmentUserModel()
					{
						ID = GetUid(DepartmentUserEntity.TableName).ToInt32(),
						OrganizationID = orgid,
						DepartmentID = d,
						UserID = u
					});
				}
			}
		}
        #endregion

        #region 根据号码查找人员
        public UserModel GetPeopleByCallNum(string callNum)
        {
            try { 
                var list = FindByWhere(n => n.ext == callNum || n.phone == callNum
                || n.landline == callNum || n.office_phone == callNum,
                UserModel.PK, true);
                if (list.Count > 0)
                {
                    var entity = list.First();
                    UserModel model = new UserModel()
                    {
                        ID = entity.id,
                        Guid = entity.guid,
                        OrganizationID = entity.organization_id,
                        OrganizationName = _organizationService.GetNameById(entity.organization_id.ToInt32()),
                        DrpartmentID = entity.drpartment_id,
                        Username = entity.username,
                        Password = entity.password,
                        Name = entity.name,
                        EnglishName = entity.english_name,
                        Alias = entity.alias,
                        Gender = entity.gender,
                        Birthday = entity.birthday,
                        QQ = entity.QQ,
                        RegisterDate = entity.register_date,
                        Photo = entity.photo,
                        Post = entity.post,
                        Email = entity.email,
                        Phone = entity.phone,
                        Landline = entity.landline,
                        OfficePhone = entity.office_phone,
                        HomePhone = entity.home_phone,
                        Ext = entity.ext,
                        LastTime = entity.last_time,
                        LastIp = entity.last_ip,
                        SystemFlag = entity.system_flag,
                        Status = entity.status,
                        IsOnline = entity.is_online,
                        IsDelete = entity.is_delete,
                        Activate = entity.activate,
                        CreatorID = entity.creator_id,
                        CreatorName = entity.creator_name,
                        CreationDate = entity.creation_date,
                        ModifierID = entity.modifier_id,
                        ModifierName = entity.modifier_name,
                        ModificationDate = entity.modification_date,
                    };
                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) {
                _logger.LogError(e.ToString());
                throw e;
            }
        }
        #endregion
    }


}

