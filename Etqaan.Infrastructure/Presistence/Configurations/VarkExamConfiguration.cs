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


        }
    }
}
