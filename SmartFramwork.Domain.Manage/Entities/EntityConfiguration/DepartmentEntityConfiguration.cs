using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class DepartmentEntityConfiguration : EntityMappingConfiguration<DepartmentEntity>
	{
		public override void Map(EntityTypeBuilder<DepartmentEntity> builder)
		{
			builder.ToTable(DepartmentEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}