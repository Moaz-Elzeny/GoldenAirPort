using GoldenAirport.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(255);

            builder.Property(e => e.ServiceFees)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            
            builder.Property(e => e.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.DailyGoal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.PaymentMethod)
                .IsRequired();

            builder.Property(e => e.LastLogin)
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
