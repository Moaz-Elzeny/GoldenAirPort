using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Persistence.Configurations
{
    public class QuestionSkillConfiguration : IEntityTypeConfiguration<QuestionSkill>
    {
        public void Configure(EntityTypeBuilder<QuestionSkill> builder)
        {
            builder.ToTable("QuestionSkills");

            builder.HasKey(qs => qs.Id);

            builder.Property(qs => qs.Id)
                .IsRequired();

            builder.Property(qs => qs.QuestionId)
                .IsRequired();

            builder.Property(qs => qs.SkillId)
                .IsRequired();



        }
    }
}
