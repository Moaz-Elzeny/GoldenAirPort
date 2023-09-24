using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class DailyGoalConfiguration : IEntityTypeConfiguration<DailyGoal>
    {
        public void Configure(EntityTypeBuilder<DailyGoal> builder)
        {
            builder.ToTable("DailyGoals");

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Goal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(b => b.Date).HasColumnType("DATETIME").IsRequired();

            builder.Property(a => a.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(a => !a.Deleted);
            builder.Property(a => a.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(b => b.ModificationDate).HasColumnType("DATETIME");
            builder.Property(a => a.ModifiedById).HasMaxLength(50);
        }
    }
}
