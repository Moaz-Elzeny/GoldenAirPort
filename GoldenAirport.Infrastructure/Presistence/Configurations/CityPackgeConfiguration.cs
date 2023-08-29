using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class CityPackgeConfiguration : IEntityTypeConfiguration<CityPackage>
    {
        public void Configure(EntityTypeBuilder<CityPackage> builder)
        {
            builder.ToTable("CityPackage");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.PackageId)
               .IsRequired();

            builder.Property(e => e.CityId)
               .IsRequired();
        }
    }
}
