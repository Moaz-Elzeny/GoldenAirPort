using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class ExternalExamConfiguration : IEntityTypeConfiguration<ExternalExam>
    {
        public void Configure(EntityTypeBuilder<ExternalExam> builder)
        {
            builder.ToTable("ExternalExams");

            builder.HasKey(ee => ee.Id);

            builder.Property(ee => ee.Id)
                .IsRequired();

            builder.Property(ee => ee.NameAr)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(ee => ee.NameEn)
                .HasMaxLength(256);

            builder.Property(ee => ee.ExamType)
                .IsRequired();

            builder.Property(ee => ee.NotifyParentAndStudent)
                .IsRequired();

            builder.Property(ee => ee.CanShowResult)
                .IsRequired();

            builder.Property(ee => ee.Duration)
                .IsRequired();

            builder.Property(ee => ee.SubjectId)
                .IsRequired();

            builder.HasOne(ee => ee.Subject)
                .WithMany(s => s.ExternalExams)
                .HasForeignKey(ee => ee.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ee => ee.GradeId)
                .IsRequired();



            builder.Property(ee => ee.Deleted).HasDefaultValue(false);
            builder.Property(ee => ee.Active).HasDefaultValue(true);
            builder.HasQueryFilter(ee => !ee.Deleted);
            builder.Property(ee => ee.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(ee => ee.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(ee => ee.ModificationDate).HasColumnType("DATETIME");
            builder.Property(ee => ee.ModifiedById).HasMaxLength(50);
        }
    }
}
