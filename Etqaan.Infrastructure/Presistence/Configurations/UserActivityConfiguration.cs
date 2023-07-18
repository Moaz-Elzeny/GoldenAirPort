using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.ToTable("UserActivities");

            // Configure primary key
            builder.HasKey(ua => ua.Id);

            // Configure properties
            builder.Property(ua => ua.ActivityDate)
                .IsRequired();

            builder.Property(ua => ua.AppUserId)
                .IsRequired();

            builder.Property(ua => ua.ActivityId)
                .IsRequired();

            builder.Property(ua => ua.Duration)
                .IsRequired();


        }
    }
}
