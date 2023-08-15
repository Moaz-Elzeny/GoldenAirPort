using GoldenAirport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenAirport.Infrastructure.Presistence.Configurations
{
    public class AdultConfiguration : IEntityTypeConfiguration<Adult>
    {
        public void Configure(EntityTypeBuilder<Adult> builder)
        {
            builder.ToTable("Adult");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.FirstName).HasMaxLength(255)
               .IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(255)
              .IsRequired();

            builder.Property(e => e.DateOfBirth)
               .IsRequired();

            builder.Property(e => e.PassportNo)
                .HasMaxLength(20);
        }
    }
}
