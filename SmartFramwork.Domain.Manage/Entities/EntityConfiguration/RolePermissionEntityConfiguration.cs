using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class RolePermissionEntityConfiguration : EntityMappingConfiguration<RolePermissionEntity>
	{
		public override void Map(EntityTypeBuilder<RolePermissionEntity> builder)
		{
			builder.ToTable(RolePermissionEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}