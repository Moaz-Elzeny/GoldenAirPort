using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class StandardConfiguration : IEntityTypeConfiguration<Standard>
    {
        public void Configure(EntityTypeBuilder<Standard> builder)
        {
            builder.ToTable("Standards");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.NameAr)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(s => s.NameEn)
                .HasMaxLength(256);

            builder.Property(s => s.AxisId)
                .IsRequired();


            builder.Property(s => s.Deleted).HasDefaultValue(false);
            builder.Property(s => s.Active).HasDefaultValue(true);
            builder.HasQueryFilter(s => !s.Deleted);
            builder.Property(s => s.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(s => s.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(s => s.ModificationDate).HasColumnType("DATETIME");
            builder.Property(s => s.ModifiedById).HasMaxLength(50);
        }
    }
}
