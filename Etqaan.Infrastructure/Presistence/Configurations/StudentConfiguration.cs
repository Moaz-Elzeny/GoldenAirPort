using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.AppUserId)
                .IsRequired();

            builder.Property(s => s.SchoolId)
                .IsRequired();

            builder.Property(s => s.SchoolGradeId)
                .IsRequired();

            builder.Property(s => s.SchoolClassId)
                .IsRequired();

            builder.Property(s => s.StudentCategory)
                .IsRequired();

            builder.Property(s => s.LearningSystem);

            builder.Property(s => s.ParentId);

            builder.Property(s => s.StudentIdInSchool);

            builder.Property(s => s.StudentAbility);

            builder.Property(s => s.Accomodation);

            builder.Property(s => s.V)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Q)
                .HasColumnType("decimal(18,2)");


            builder.Property(s => s.NV)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.S)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.MeanSAS)
                .HasColumnType("decimal(18,2)");

            builder.HasMany(s => s.AboutStudents)
            .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.AppUser)
                .WithOne()
                .HasForeignKey<Student>(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.School)
                .WithMany()
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.SchoolGrade)
                .WithMany()
                .HasForeignKey(s => s.SchoolGradeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.SchoolClass)
                .WithMany()
                .HasForeignKey(s => s.SchoolClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Parent)
                .WithMany()
                .HasForeignKey(s => s.ParentId)
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
