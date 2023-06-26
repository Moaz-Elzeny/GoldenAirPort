using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Domain.Entities
{
    public class VarkExamConfiguration : IEntityTypeConfiguration<VarkExam>
    {
        public void Configure(EntityTypeBuilder<VarkExam> builder)
        {
            builder.ToTable("VarkExams");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).HasMaxLength(500).IsRequired();


            builder.HasMany(e => e.VarkQuestions)
                .WithOne(q => q.VarkExam)
                .HasForeignKey(q => q.VarkExamId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.VarkExamResponses)
                .WithOne(r => r.VarkExam)
                .HasForeignKey(r => r.VarkExamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
