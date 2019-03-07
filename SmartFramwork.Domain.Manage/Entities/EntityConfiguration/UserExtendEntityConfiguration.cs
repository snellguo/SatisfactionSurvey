using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class UserExtendEntityConfiguration : EntityMappingConfiguration<UserExtendEntity>
	{
		public override void Map(EntityTypeBuilder<UserExtendEntity> builder)
		{
			builder.ToTable(UserExtendEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}