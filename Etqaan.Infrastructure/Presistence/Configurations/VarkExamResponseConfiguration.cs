using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Domain.Entities
{
    public class VarkExamResponseConfiguration : IEntityTypeConfiguration<VarkExamResponse>
    {
        public void Configure(EntityTypeBuilder<VarkExamResponse> builder)
        {
            builder.ToTable("VarkExamResponses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.StudentId).IsRequired();
            builder.Property(e => e.SubmissionDate).IsRequired();
            builder.Property(e => e.TotalVarkScore).IsRequired();

            builder.HasOne(e => e.VarkExam)
                .WithMany(exam => exam.VarkExamResponses)
                .HasForeignKey(e => e.VarkExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
