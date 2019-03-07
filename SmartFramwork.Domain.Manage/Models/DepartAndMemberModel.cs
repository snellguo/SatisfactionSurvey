using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Models
{
	/// <summary>
	/// 部门及人员信息
	/// </summary>
	public class DepartAndMemberModel
	{
		public IList<DepartmentModel> Depart { get; set; }

		public IList<UserModel> Member { get; set; }

        public DepartmentModel CurrentDepart { get; set; }
    }
}
