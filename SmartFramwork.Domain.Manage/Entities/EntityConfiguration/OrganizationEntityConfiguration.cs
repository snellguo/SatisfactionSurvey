using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.Manage.Entities.EntityConfiguration
{
	public class OrganizationEntityConfiguration : EntityMappingConfiguration<OrganizationEntity>
	{
		public override void Map(EntityTypeBuilder<OrganizationEntity> builder)
		{
			builder.ToTable(OrganizationEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}