using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Package");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.StartingDate)
                .IsRequired();

            builder.Property(e => e.EndingDate)
                .IsRequired();

            builder.Property(e => e.IsRefundable)
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.PriceLessThan2YearsOld)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.PriceLessThan12YearsOld)
                .HasColumnType("decimal(18,2)");

            //builder.Property(e => e.Guests).HasMaxLength(255)
            //    .IsRequired();

            //builder.Property(e => e.TripHours)
            //    .IsRequired();

            builder.HasOne(mc => mc.City)
              .WithMany(mc => mc.Packages)
              .HasForeignKey(mc => mc.FromCityId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.Deleted).HasDefaultValue(false);
            builder.Property(a => a.Active).HasDefaultValue(true);
            builder.HasQueryFilter(a => !a.Deleted);
            builder.Property(a => a.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(b => b.ModificationDate).HasColumnType("DATETIME");
            builder.Property(a => a.ModifiedById).HasMaxLength(50);
        }
    }
}
