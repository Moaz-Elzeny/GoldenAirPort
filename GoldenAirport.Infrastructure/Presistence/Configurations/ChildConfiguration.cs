using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class ChildConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.ToTable("Child");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.PassportNo)
                .HasMaxLength(20);

            builder.Property(e => e.AgeRange)
               .IsRequired();
        }
    }
}
