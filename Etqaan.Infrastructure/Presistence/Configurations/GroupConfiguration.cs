using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .IsRequired();

            builder.Property(g => g.NameAr)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(g => g.NameEn)
                .HasMaxLength(256);

            builder.Property(g => g.Deleted).HasDefaultValue(false);
            builder.Property(g => g.Active).HasDefaultValue(true);
            builder.HasQueryFilter(g => !g.Deleted);
            builder.Property(g => g.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(g => g.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(g => g.ModificationDate).HasColumnType("DATETIME");
            builder.Property(g => g.ModifiedById).HasMaxLength(50);
        }
    }
}
