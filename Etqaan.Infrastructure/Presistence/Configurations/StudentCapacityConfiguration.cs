using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class StudentCapacityConfiguration : IEntityTypeConfiguration<StudentCapacity>
    {
        public void Configure(EntityTypeBuilder<StudentCapacity> builder)
        {
            builder.ToTable("StudentCapacities");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id)
                .IsRequired();

            builder.Property(sc => sc.Name)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
