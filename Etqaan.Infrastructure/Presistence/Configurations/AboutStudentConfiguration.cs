using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class AboutStudentConfiguration : IEntityTypeConfiguration<AboutStudent>
    {
        public void Configure(EntityTypeBuilder<AboutStudent> builder)
        {
            builder.ToTable("AboutStudents");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Student)
                .WithMany(a => a.AboutStudents)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.About)
                .WithMany(a => a.AboutStudents)
                .HasForeignKey(a => a.AboutId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
