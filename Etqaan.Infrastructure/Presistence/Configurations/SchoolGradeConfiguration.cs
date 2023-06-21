using Etqaan.Domain.Entities;
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
        }
    }
}
