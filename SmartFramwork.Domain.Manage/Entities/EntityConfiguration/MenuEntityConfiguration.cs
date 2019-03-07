using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class MenuEntityConfiguration : EntityMappingConfiguration<MenuEntity>
	{
		public override void Map(EntityTypeBuilder<MenuEntity> builder)
		{
			builder.ToTable(MenuEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}