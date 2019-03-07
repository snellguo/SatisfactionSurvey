using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class DeviceEntityConfiguration : EntityMappingConfiguration<DeviceEntity>
	{
		public override void Map(EntityTypeBuilder<DeviceEntity> builder)
		{
			builder.ToTable(DeviceEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}