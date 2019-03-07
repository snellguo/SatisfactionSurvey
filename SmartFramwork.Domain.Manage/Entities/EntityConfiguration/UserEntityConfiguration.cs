using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class UserEntityConfiguration : EntityMappingConfiguration<UserEntity>
	{
		public override void Map(EntityTypeBuilder<UserEntity> builder)
		{
			builder.ToTable(UserEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}