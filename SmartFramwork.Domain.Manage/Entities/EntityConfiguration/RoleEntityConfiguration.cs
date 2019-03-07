using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class RoleEntityConfiguration : EntityMappingConfiguration<RoleEntity>
	{
		public override void Map(EntityTypeBuilder<RoleEntity> builder)
		{
			builder.ToTable(RoleEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}