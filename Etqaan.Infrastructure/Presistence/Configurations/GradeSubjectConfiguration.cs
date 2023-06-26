using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class GradeSubjectConfiguration : IEntityTypeConfiguration<GradeSubject>
    {
        public void Configure(EntityTypeBuilder<GradeSubject> builder)
        {
            builder.ToTable("GradeSubjects");

            builder.HasKey(gs => gs.Id);

            builder.Property(gs => gs.Id)
                .IsRequired();

            builder.HasOne(gs => gs.Grade)
                .WithMany(g => g.GradeSubjects)
                .HasForeignKey(gs => gs.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gs => gs.Subject)
                .WithMany(sub => sub.GradeSubjects)
                .HasForeignKey(gs => gs.SubjectId)
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
