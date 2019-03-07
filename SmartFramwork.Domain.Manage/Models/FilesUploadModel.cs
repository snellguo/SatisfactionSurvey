using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SmartFramwork.Domain.Manage.Models
{
	public class FilesUploadModel
	{
		// Excel 文件
		//[Required]
		//[Remote("IsExcelSelected", "Student", AdditionalFields = "fileExcel", ErrorMessage = "请选择一个需要导入的 Excel 文件" )]
		public IFormFile fileExcel { get; set; }

		// 照片文件
		public IEnumerable<IFormFile> filePhotos { get; set; }
        
	}
}
