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



        }
    }
}
