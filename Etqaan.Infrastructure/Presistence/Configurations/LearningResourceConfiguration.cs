using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class LearningResourceConfiguration : IEntityTypeConfiguration<LearningResource>
    {
        public void Configure(EntityTypeBuilder<LearningResource> builder)
        {
            builder.ToTable("LearningResources");

            builder.HasKey(lr => lr.Id);

            builder.Property(lr => lr.Id)
                .IsRequired();

            builder.Property(lr => lr.NameAr)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(lr => lr.NameEn)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(lr => lr.ResourceFileType)
                .IsRequired();



            builder.Property(lr => lr.ReourceTargetedCategory)
                .IsRequired();


            builder.Property(lr => lr.FilePath).HasMaxLength(200)
                .IsRequired();

            builder.Property(lr => lr.CoverImagePath).HasMaxLength(200)
               ;

            builder.Property(lr => lr.Size).HasMaxLength(15);

            builder.Property(lr => lr.SubjectId)
                .IsRequired();

            builder.Property(lr => lr.GradeId)
                .IsRequired();

            builder.HasOne(lr => lr.Subject)
                .WithMany(s => s.LearningResources)
                .HasForeignKey(lr => lr.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lr => lr.Grade)
                .WithMany(g => g.LearningResources)
                .HasForeignKey(lr => lr.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

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
