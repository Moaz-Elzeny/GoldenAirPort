using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class AboutStudentConfiguration : IEntityTypeConfiguration<AboutStudent>
    {
        public void Configure(EntityTypeBuilder<AboutStudent> builder)
        {
            builder.ToTable("AboutStudents");

            builder.HasKey(a => a.Id);


        }
    }
}
