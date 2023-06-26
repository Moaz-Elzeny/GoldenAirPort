﻿using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class SchoolGradeConfiguration : IEntityTypeConfiguration<SchoolGrade>
    {
        public void Configure(EntityTypeBuilder<SchoolGrade> builder)
        {
            builder.ToTable("SchoolGrades");

            builder.HasKey(sg => sg.Id);

            builder.Property(sg => sg.Id)
                .IsRequired();

            builder.Property(sg => sg.SchoolId)
                .IsRequired();

            builder.Property(sg => sg.GradeId)
                .IsRequired();

            builder.HasOne(sg => sg.School)
                .WithMany(s => s.SchoolGrades)
                .HasForeignKey(sg => sg.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sg => sg.Grade)
                .WithMany()
                .HasForeignKey(sg => sg.GradeId)
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
