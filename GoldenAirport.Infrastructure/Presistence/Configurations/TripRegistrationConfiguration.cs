﻿using GoldenAirport.Domain.Entities;
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

           builder.Property(x => x.AdultCost)
              .HasColumnType("decimal(18,2)")
              .IsRequired();
            
           builder.Property(x => x.ChildCost)
              .HasColumnType("decimal(18,2)");

            builder.Property(x => x.AdminFees)
              .HasColumnType("decimal(18,2)");
            
            builder.Property(x => x.EmployeeFees)
              .HasColumnType("decimal(18,2)");

            builder.Property(x => x.OtherFees)
              .HasColumnType("decimal(18,2)");

            builder.Property(x => x.TotalAmount)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(x => x.Email).HasMaxLength(500)
              .IsRequired();

            builder.Property(x => x.PhoneNumber).HasMaxLength(20)
             .IsRequired();

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
