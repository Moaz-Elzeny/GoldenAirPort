using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class SchoolClassConfiguration : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.ToTable("SchoolClasses");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id)
                .IsRequired();

            builder.Property(sc => sc.NameAr)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sc => sc.NameEn)

                .HasMaxLength(100);

            builder.Property(sc => sc.SchoolId)
                .IsRequired();

            builder.Property(sc => sc.SchoolGradeId)
                .IsRequired();



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
