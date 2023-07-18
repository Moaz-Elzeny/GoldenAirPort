using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Persistence.Configurations
{
    public class StudentGroupConfiguration : IEntityTypeConfiguration<StudentGroup>
    {
        public void Configure(EntityTypeBuilder<StudentGroup> builder)
        {
            builder.ToTable("StudentGroups");

            builder.HasKey(sg => sg.Id);

            builder.Property(sg => sg.Id)
                .IsRequired();

            builder.Property(sg => sg.GroupId)
                .IsRequired();





        }
    }
}
