using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class AxisConfiguration : IEntityTypeConfiguration<Axis>
    {
        public void Configure(EntityTypeBuilder<Axis> builder)
        {
            builder.ToTable("Axes");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .IsRequired();

            builder.Property(a => a.NameAr).HasMaxLength(256)
                .IsRequired();

            builder.Property(a => a.NameEn).HasMaxLength(256);

            builder.Property(a => a.SkillId)
                .IsRequired();

            builder.HasOne(a => a.Skill)
                .WithMany(s => s.Axes)
                .HasForeignKey(a => a.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

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
