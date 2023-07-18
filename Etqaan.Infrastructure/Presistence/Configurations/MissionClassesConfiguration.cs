using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class MissionClassesConfiguration : IEntityTypeConfiguration<MissionClasses>
    {
        public void Configure(EntityTypeBuilder<MissionClasses> builder)
        {
            builder.ToTable("MissionClasses");

            builder.HasKey(mc => mc.Id);

            builder.Property(mc => mc.Id)
                .IsRequired();

            builder.Property(mc => mc.SchoolClassId)
                .IsRequired();

            builder.Property(mc => mc.MissionId)
                .IsRequired();




        }
    }
}
