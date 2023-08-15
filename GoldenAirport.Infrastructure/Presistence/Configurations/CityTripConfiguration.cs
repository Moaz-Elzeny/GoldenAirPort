using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class CityTripConfiguration : IEntityTypeConfiguration<CityTrip>
    {
        public void Configure(EntityTypeBuilder<CityTrip> builder)
        {
            builder.ToTable("CityTrip");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.TripId)
               .IsRequired();

            builder.Property(e => e.CityId)
               .IsRequired();
        }
    }
}
