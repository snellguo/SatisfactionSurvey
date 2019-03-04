using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFramwork.Domain.SatisfactionSurvey.Service;
using SmartFramwork.Web.Models;
using Microsoft.Extensions.Localization;
using SmartFramwork.Domain.SatisfactionSurvey.Models;
using SmartFramwork.Domain.SatisfactionSurvey.Resources;

namespace SatisfactionSurvey.UI.SatisfactionSurvey.Areas.SatisfactionSurvey.Controllers
{
	//[Area("SatisfactionSurvey")]
	public class SatisfactionSurveyController : Controller
    {
		private readonly IStringLocalizer<SatisfactionSurveyResource> _sharedLocalizer;
		private readonly ILogger _logger;
		private readonly ISatisfactionSurveyService _satisfactionsurveyService;

		public SatisfactionSurveyController(IStringLocalizer<SatisfactionSurveyResource> sharedLocalizer,ILogger<SatisfactionSurveyController> logger, ISatisfactionSurveyService satisfactionsurveyService)
		{
			_sharedLocalizer = sharedLocalizer;
			_logger = logger;
			_satisfactionsurveyService = satisfactionsurveyService;
		}

		#region 首页
		public ActionResult Index()
        {
            return View(new SatisfactionSurveyModel());
        }
		#endregion

		#region 列表数据
		public IActionResult GetByPageList([FromBody] JqGridModel model)
		{
			try
			{
				var result = _satisfactionsurveyService.GetPageList(model);
				return Json(result);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		#endregion

		#region 详情
		public IActionResult Details(int id)
        {
            return View(_satisfactionsurveyService.GetModelByID(id));
        }
		#endregion

		#region 新建及保存
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SatisfactionSurveyModel model)
        {
			var result = new MsgResult();
			try
            {
				// TODO: Add insert logic here
				_satisfactionsurveyService.Create(model);
            }
            catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return new ErrorResult();
			}

			return Json(result);
        }
		#endregion

		#region 修改及保存
		public IActionResult Edit(int id)
        {
			try
			{
				return View(_satisfactionsurveyService.GetModelByID(id));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return new ErrorResult();
			}
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(SatisfactionSurveyModel model)
		{
			var result = new MsgResult();
			try
			{
				// TODO: Add update logic here
				_satisfactionsurveyService.Edit(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return new ErrorResult();
			}

			return Json(result);
		}
		#endregion

		#region 删除
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var result = new MsgResult();
			try
			{
				// TODO: Add delete logic here
				_satisfactionsurveyService.Delete(id);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				return new ErrorResult();
			}
			return Json(result);
		}
		#endregion
	}
}