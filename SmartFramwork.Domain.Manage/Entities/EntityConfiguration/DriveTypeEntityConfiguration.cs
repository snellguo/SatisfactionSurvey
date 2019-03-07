using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class DriveTypeEntityConfiguration : EntityMappingConfiguration<DriveTypeEntity>
	{
		public override void Map(EntityTypeBuilder<DriveTypeEntity> builder)
		{
			builder.ToTable(DriveTypeEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}