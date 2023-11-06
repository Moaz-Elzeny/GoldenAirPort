using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class AdminDetailsConfiguration : IEntityTypeConfiguration<AdminDetails>
    {
        public void Configure(EntityTypeBuilder<AdminDetails> builder)
        {
            builder.ToTable("AdminDetails");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.ServiceFees)
                .HasColumnType("decimal(18,2)");

            builder.Property(u => u.TaxValue).HasColumnType("decimal(18,2)");

            builder.Property(u => u.BookingTime).HasColumnType("decimal(18,2)");

            builder.Property(a => a.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(a => !a.Deleted);
            builder.Property(a => a.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(b => b.ModificationDate).HasColumnType("DATETIME");
            builder.Property(a => a.ModifiedById).HasMaxLength(50);
        }
    }
}
