using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class MissionStudentsConfiguration : IEntityTypeConfiguration<MissionStudents>
    {
        public void Configure(EntityTypeBuilder<MissionStudents> builder)
        {
            builder.ToTable("MissionStudents");

            builder.HasKey(ms => ms.Id);

            builder.Property(ms => ms.Id)
                .IsRequired();

            builder.Property(ms => ms.StudentId)
                .IsRequired();

            builder.Property(ms => ms.MissionId)
                .IsRequired();

            builder.HasOne(ms => ms.Mission)
                .WithMany(m => m.MissionStudents)
                .HasForeignKey(ms => ms.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ms => ms.Student)
                .WithMany(s => s.MissionStudents)
                .HasForeignKey(ms => ms.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
