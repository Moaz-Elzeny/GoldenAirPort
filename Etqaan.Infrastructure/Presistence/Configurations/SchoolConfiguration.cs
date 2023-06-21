﻿using Etqaan.Domain.Entities;
using Etqaan.Domain.Entities.Auth;
using Etqaan.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("Schools");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.AppUserId)
                .IsRequired();

            builder.Property(s => s.NameAr).HasMaxLength(250)
                .IsRequired();

            builder.Property(s => s.NameEn).HasMaxLength(250)
                .IsRequired();

            builder.Property(s => s.LogoImage).HasMaxLength(200);

            builder.Property(s => s.CountryId)
                .IsRequired();

            builder.Property(s => s.CityId)
                .IsRequired();

            builder.Property(s => s.OrganizationType)
                .IsRequired();

            builder.Property(s => s.LearningSystem)
                .IsRequired();

            builder.Property(s => s.StudentCapacityId)
                .IsRequired();

            builder.Property(s => s.TeachersCount);

            builder.Property(s => s.ClassesCount);

            builder.Property(s => s.SubscriptionId)
                .IsRequired();

            builder.Property(s => s.SubscriptionStartDate)
                .IsRequired();

            builder.Property(s => s.SubscriptionPeriodId)
                .IsRequired();

            builder.Property(s => s.SubscriptionPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(s => s.AppUser)
                .WithOne()
                .HasForeignKey<School>(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.City)
                .WithMany()
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Country)
                .WithMany()
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.StudentCapacity)
                .WithMany()
                .HasForeignKey(s => s.StudentCapacityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Subscription)
                .WithMany()
                .HasForeignKey(s => s.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.SubscriptionPeriod)
                .WithMany()
                .HasForeignKey(s => s.SubscriptionPeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Students)
                .WithOne(s => s.School)
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.SchoolClasses)
                .WithOne(sc => sc.School)
                .HasForeignKey(sc => sc.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.SchoolGrades)
                .WithOne(sg => sg.School)
                .HasForeignKey(sg => sg.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
