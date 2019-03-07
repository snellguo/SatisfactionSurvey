using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class DictionaryEntityConfiguration : EntityMappingConfiguration<DictionaryEntity>
	{
		public override void Map(EntityTypeBuilder<DictionaryEntity> builder)
		{
			builder.ToTable(DictionaryEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}