﻿using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
             builder.ToTable("Notifications");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Title).HasMaxLength(50);
            builder.Property(n => n.Content).HasMaxLength(255);
     
            builder.Property(n => n.Date).IsRequired();
            builder.Property(n => n.AppUserId).IsRequired();
            builder.Property(a => a.Seen).HasDefaultValue(false);

            builder.HasOne(n => n.AppUser)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.AppUserId);
        }
    }
}
