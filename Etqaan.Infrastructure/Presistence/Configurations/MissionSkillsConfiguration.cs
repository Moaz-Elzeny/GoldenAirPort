using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class MissionSkillsConfiguration : IEntityTypeConfiguration<MissionSkills>
    {
        public void Configure(EntityTypeBuilder<MissionSkills> builder)
        {
            builder.ToTable("MissionSkills");

            builder.HasKey(ms => ms.Id);

            builder.Property(ms => ms.Id)
                .IsRequired();

            builder.Property(ms => ms.MissionId)
                .IsRequired();

            builder.Property(ms => ms.SkillId)
                .IsRequired();

            builder.HasOne(ms => ms.Mission)
                .WithMany(m => m.MissionSkills)
                .HasForeignKey(ms => ms.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ms => ms.Skill)
                .WithMany(s => s.MissionSkills)
                .HasForeignKey(ms => ms.SkillId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
