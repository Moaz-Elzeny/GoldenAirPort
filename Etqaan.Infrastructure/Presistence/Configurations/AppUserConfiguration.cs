using Etqaan.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{


    namespace Etqaan.Infrastructure.Data.Configurations
    {
        public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
        {
            public void Configure(EntityTypeBuilder<AppUser> builder)
            {
                builder.ToTable("AppUsers");

                // Configure primary key
                builder.HasKey(u => u.Id);

                // Configure properties
                builder.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.DateOfBirth)
                    ;

                builder.Property(u => u.NationalIdNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                builder.Property(u => u.AddressDetails)
                 
                    .HasMaxLength(250);

                builder.Property(u => u.ProfilePicture)
                    .HasMaxLength(100);


                builder.Property(u => u.NationalityId)
                    .IsRequired();

                // Configure foreign key relationship with Nationality entity
                builder.HasOne(u => u.Nationality)
                    .WithMany(n => n.AppUsers)
                    .HasForeignKey(u => u.NationalityId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure enumeration properties
                builder.Property(u => u.Gender)
                    .IsRequired();


                builder.Property(u => u.Religion)
                    ;


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
