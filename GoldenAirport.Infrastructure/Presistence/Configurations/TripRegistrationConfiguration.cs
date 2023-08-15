using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class TripRegistrationConfiguration : IEntityTypeConfiguration<TripRegistration>
    {
        public void Configure(EntityTypeBuilder<TripRegistration> builder)
        {
            builder.ToTable("TripRegistration");

           builder.HasKey(x => x.Id);

           builder.Property(x => x.PackageCost)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(x => x.TaxesAdndFees)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(x => x.OutherFees)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(x => x.TotalAmount)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(x => x.Email).HasMaxLength(500)
              .IsRequired();

            builder.Property(x => x.PhoneNumber).HasMaxLength(20)
             .IsRequired();
        }
    }
}
