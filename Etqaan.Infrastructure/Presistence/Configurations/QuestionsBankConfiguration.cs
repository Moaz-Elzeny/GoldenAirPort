using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Persistence.Configurations
{
    public class QuestionsBankConfiguration : IEntityTypeConfiguration<QuestionsBank>
    {
        public void Configure(EntityTypeBuilder<QuestionsBank> builder)
        {
            builder.ToTable("QuestionsBanks");

            builder.HasKey(qb => qb.Id);

            builder.Property(qb => qb.Id)
                .IsRequired();

            builder.Property(qb => qb.NameAr)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(qb => qb.NameEn)
                .HasMaxLength(256);

            builder.Property(qb => qb.QuestionsBankType)
                .IsRequired();

            builder.Property(qb => qb.SubjectId)
                .IsRequired();

            builder.Property(qb => qb.StudentCategory)
                .IsRequired();

            builder.HasOne(qb => qb.Grade)
                .WithMany()
                .HasForeignKey(qb => qb.GradeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(qb => qb.ExamType)
                .IsRequired();

            builder.HasOne(qb => qb.Subject)
                .WithMany()
                .HasForeignKey(qb => qb.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);



            builder.HasMany(qb => qb.Questions)
                .WithOne(q => q.QuestionsBank)
                .HasForeignKey(q => q.QuestionBankId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(qb => qb.Deleted).HasDefaultValue(false);
            builder.Property(qb => qb.Active).HasDefaultValue(true);
            builder.Property(qb => qb.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(qb => qb.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(qb => qb.ModificationDate).HasColumnType("DATETIME");
            builder.Property(qb => qb.ModifiedById).HasMaxLength(50);
        }
    }
}
