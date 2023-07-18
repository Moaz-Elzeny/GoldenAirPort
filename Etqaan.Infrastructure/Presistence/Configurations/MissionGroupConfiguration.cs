using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class MissionGroupConfiguration : IEntityTypeConfiguration<MissionGroup>
    {
        public void Configure(EntityTypeBuilder<MissionGroup> builder)
        {
            builder.ToTable("MissionGroups");

            builder.HasKey(mg => mg.Id);

            builder.Property(mg => mg.Id)
                .IsRequired();

            builder.Property(mg => mg.MissionId)
                .IsRequired();

            builder.Property(mg => mg.GroupId)
                .IsRequired();



        }
    }
}
