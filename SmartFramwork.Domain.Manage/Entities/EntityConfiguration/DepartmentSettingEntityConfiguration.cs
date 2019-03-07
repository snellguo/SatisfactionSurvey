using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class DepartmentSettingEntityConfiguration : EntityMappingConfiguration<DepartmentSettingEntity>
	{
		public override void Map(EntityTypeBuilder<DepartmentSettingEntity> builder)
		{
			builder.ToTable(DepartmentSettingEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}