using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class LearningOutcomeConfiguration : IEntityTypeConfiguration<LearningOutcome>
    {
        public void Configure(EntityTypeBuilder<LearningOutcome> builder)
        {
            builder.ToTable("LearningOutcomes");

            builder.HasKey(lo => lo.Id);

            builder.Property(lo => lo.Id)
                .IsRequired();

            builder.Property(lo => lo.Number)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(lo => lo.Description).HasMaxLength(1000)
                .IsRequired();

            builder.Property(lo => lo.StandardId)
                .IsRequired();


            builder.Property(lo => lo.Deleted).HasDefaultValue(false);
            builder.Property(lo => lo.Active).HasDefaultValue(true);
            builder.HasQueryFilter(lo => !lo.Deleted);
            builder.Property(lo => lo.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(lo => lo.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(lo => lo.ModificationDate).HasColumnType("DATETIME");
            builder.Property(lo => lo.ModifiedById).HasMaxLength(50);
        }
    }
}
