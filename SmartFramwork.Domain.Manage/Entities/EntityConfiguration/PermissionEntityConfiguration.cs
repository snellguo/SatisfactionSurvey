using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class PermissionEntityConfiguration : EntityMappingConfiguration<PermissionEntity>
	{
		public override void Map(EntityTypeBuilder<PermissionEntity> builder)
		{
			builder.ToTable(PermissionEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}