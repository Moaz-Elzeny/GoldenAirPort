using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .IsRequired();

            builder.Property(q => q.QuestionType)
                .IsRequired();

            builder.Property(q => q.QuestionHead)
                .HasMaxLength(256);

            builder.Property(q => q.QuestionHeadImageIcon)
                .HasMaxLength(256);

            builder.Property(q => q.QuestionHeadVoiceRecord)
                .HasMaxLength(256);

            builder.Property(q => q.ChoicesVoiceRecord)
                .HasMaxLength(256);

            builder.Property(q => q.LessonName)
                .HasMaxLength(256);

            builder.Property(q => q.QuestionNumber)
                .IsRequired();

            builder.Property(q => q.CorrectAnswer)
                .HasMaxLength(256);

            builder.HasOne(q => q.QuestionsBank)
                .WithMany(qb => qb.Questions)
                .HasForeignKey(q => q.QuestionBankId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.ExternalExam)
                .WithMany(e => e.Questions)
                .HasForeignKey(q => q.ExternalExamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.Mission)
                .WithMany(m => m.Questions)
                .HasForeignKey(q => q.MissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.Deleted).HasDefaultValue(false);
            builder.Property(a => a.Active).HasDefaultValue(true);
            builder.HasQueryFilter(a => !a.Deleted);
            builder.Property(a => a.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(b => b.ModificationDate).HasColumnType("DATETIME");
            builder.Property(a => a.ModifiedById).HasMaxLength(50);
        }
    }
}
