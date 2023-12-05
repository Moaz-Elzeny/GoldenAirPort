using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class StatementConfiguration : IEntityTypeConfiguration<Statement>
    {
        public void Configure(EntityTypeBuilder<Statement> builder)
        {
            builder.ToTable("Statements");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Service).HasMaxLength(250).IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(a => a.Deleted).HasDefaultValue(false);
            builder.HasQueryFilter(a => !a.Deleted);
            builder.Property(a => a.CreatedById).HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreationDate).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(b => b.ModificationDate).HasColumnType("DATETIME");
            builder.Property(a => a.ModifiedById).HasMaxLength(50);
        }
    }
}
