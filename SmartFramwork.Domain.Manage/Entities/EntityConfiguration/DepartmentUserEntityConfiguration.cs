using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class DepartmentUserEntityConfiguration : EntityMappingConfiguration<DepartmentUserEntity>
	{
		public override void Map(EntityTypeBuilder<DepartmentUserEntity> builder)
		{
			builder.ToTable(DepartmentUserEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}