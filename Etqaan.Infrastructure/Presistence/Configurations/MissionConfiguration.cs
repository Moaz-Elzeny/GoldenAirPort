using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class MissionConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.ToTable("Missions");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .IsRequired();

            builder.Property(m => m.NameAr)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(m => m.NameEn)
                .HasMaxLength(256);

            builder.Property(m => m.MissionType)
                .IsRequired();

            builder.Property(m => m.StudentCategory)
                .IsRequired();

            builder.Property(m => m.ExamType)
                .IsRequired();

            builder.Property(m => m.NotifyParentAndStudent);

            builder.Property(m => m.CanShowResult);

            builder.Property(m => m.Password)
                .HasMaxLength(256);

            builder.Property(m => m.Duration)
                .IsRequired();

            builder.Property(m => m.StartDateTime)
                .IsRequired();

            builder.Property(m => m.EndDateTime)
                .IsRequired();

            builder.Property(m => m.Deleted).HasDefaultValue(false);
            builder.Property(m => m.Active).HasDefaultValue(true);
            builder.HasQueryFilter(m => !m.Deleted);
            builder.Property(m => m.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(m => m.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(m => m.ModificationDate).HasColumnType("DATETIME");
            builder.Property(m => m.ModifiedById).HasMaxLength(50);
        }
    }
}
