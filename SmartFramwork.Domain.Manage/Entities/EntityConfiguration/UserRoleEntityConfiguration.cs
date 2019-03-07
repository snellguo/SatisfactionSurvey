using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class UserRoleEntityConfiguration : EntityMappingConfiguration<UserRoleEntity>
	{
		public override void Map(EntityTypeBuilder<UserRoleEntity> builder)
		{
			builder.ToTable(UserRoleEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}