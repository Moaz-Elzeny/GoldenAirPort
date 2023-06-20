using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(a => a.AboutStudents)
            .WithOne(s => s.About)
                .HasForeignKey(s => s.AboutId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
