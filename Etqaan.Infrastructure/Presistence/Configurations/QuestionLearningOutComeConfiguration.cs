using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Persistence.Configurations
{
    public class QuestionLearningOutComeConfiguration : IEntityTypeConfiguration<QuestionLearningOutCome>
    {
        public void Configure(EntityTypeBuilder<QuestionLearningOutCome> builder)
        {
            builder.ToTable("QuestionLearningOutComes");

            builder.HasKey(qlo => qlo.Id);

            builder.Property(qlo => qlo.Id)
                .IsRequired();

            builder.HasOne(qlo => qlo.Question)
                .WithMany(q => q.QuestionLearningOutComes)
                .HasForeignKey(qlo => qlo.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(qlo => qlo.LearningOutcome)
                .WithMany(lo => lo.QuestionLearningOutComes)
                .HasForeignKey(qlo => qlo.LearningOutcomeId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
