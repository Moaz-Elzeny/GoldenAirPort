using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class ExternalExamSkillsConfiguration : IEntityTypeConfiguration<ExternalExamSkills>
    {
        public void Configure(EntityTypeBuilder<ExternalExamSkills> builder)
        {
            builder.ToTable("ExternalExamSkills");

            builder.HasKey(ees => ees.Id);

            builder.Property(ees => ees.Id)
                .IsRequired();

            builder.Property(ees => ees.ExternalExamId)
                .IsRequired();

            builder.Property(ees => ees.SkillId)
                .IsRequired();

            builder.HasOne(ees => ees.ExternalExam)
                .WithMany(ee => ee.ExternalExamSkills)
                .HasForeignKey(ees => ees.ExternalExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ees => ees.Skill)
                .WithMany(s => s.ExternalExamSkills)
                .HasForeignKey(ees => ees.SkillId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
