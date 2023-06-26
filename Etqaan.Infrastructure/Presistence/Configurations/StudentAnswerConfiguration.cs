using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Persistence.Configurations
{
    public class StudentAnswerConfiguration : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            builder.ToTable("StudentAnswers");

            builder.HasKey(sa => sa.Id);

            builder.Property(sa => sa.Id)
                .IsRequired();

            builder.Property(sa => sa.QuestionId)
                .IsRequired();


            builder.Property(sa => sa.Answer).HasMaxLength(2000)
                .IsRequired();

            builder.HasOne(sa => sa.Question)
                .WithMany(q => q.StudentAnswers)
                .HasForeignKey(sa => sa.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.Student)
                .WithMany()
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(sa => sa.Deleted).HasDefaultValue(false);
            builder.Property(sa => sa.Active).HasDefaultValue(true);
            builder.Property(sa => sa.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(sa => sa.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(sa => sa.ModificationDate).HasColumnType("DATETIME");
            builder.Property(sa => sa.ModifiedById).HasMaxLength(50);
        }
    }
}
