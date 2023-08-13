using GoldenAirport.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{


    namespace GoldenAirport.Infrastructure.Data.Configurations
    {
        public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
        {
            public void Configure(EntityTypeBuilder<AppUser> builder)
            {
                builder.ToTable("AppUsers");

                builder.HasKey(u => u.Id);

                builder.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.ProfilePicture)
                    .HasMaxLength(100);
                    

                builder.Property(u => u.UserType)
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

}
