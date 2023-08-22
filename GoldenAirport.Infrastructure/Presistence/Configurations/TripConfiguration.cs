using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trip");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.StartingDate)
                .IsRequired();

            builder.Property(e => e.EndingDate)
                .IsRequired();

            builder.Property(e => e.IsRefundable)
                .IsRequired();
            
            builder.Property(e => e.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.Guests).HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.TripHours)                
                .IsRequired();

            builder.HasOne(mc => mc.City)
              .WithMany(mc => mc.Trips)
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
