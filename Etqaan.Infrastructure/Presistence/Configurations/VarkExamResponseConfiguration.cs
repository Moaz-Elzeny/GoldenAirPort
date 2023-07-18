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
            builder.Property(e => e.SubmissionDate).IsRequired();
            builder.Property(e => e.TotalVarkScore).IsRequired();


        }
    }
}
