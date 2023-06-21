using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class SubscriptionPeriodConfiguration : IEntityTypeConfiguration<SubscriptionPeriod>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPeriod> builder)
        {
            builder.ToTable("SubscriptionPeriods");

            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.Id)
                .IsRequired();

            builder.Property(sp => sp.Name)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
