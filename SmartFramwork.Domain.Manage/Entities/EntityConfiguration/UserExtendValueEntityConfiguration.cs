using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class UserExtendValueEntityConfiguration : EntityMappingConfiguration<UserExtendValueEntity>
	{
		public override void Map(EntityTypeBuilder<UserExtendValueEntity> builder)
		{
			builder.ToTable(UserExtendValueEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}