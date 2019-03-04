using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFramwork.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFramwork.Domain.SatisfactionSurvey.Entities.EntityConfiguration
{
	public class SatisfactionSurveyEntityConfiguration : EntityMappingConfiguration<SatisfactionSurveyEntity>
	{
		public override void Map(EntityTypeBuilder<SatisfactionSurveyEntity> builder)
		{
			builder.ToTable(SatisfactionSurveyEntity.TableName);
			builder.HasKey(p => p.id);
		}
	}
}