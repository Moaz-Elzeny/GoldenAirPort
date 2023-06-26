using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Presistence.Configurations
{
    public class SchoolClassSubjectConfiguration : IEntityTypeConfiguration<SchoolClassSubject>
    {
        public void Configure(EntityTypeBuilder<SchoolClassSubject> builder)
        {
            builder.ToTable("SchoolClassSubjects");

            builder.HasKey(scs => scs.Id);

            builder.Property(scs => scs.Id)
                .IsRequired();

            builder.HasOne(scs => scs.SchoolClass)
                .WithMany(sc => sc.SchoolClassSubjects)
                .HasForeignKey(scs => scs.SchoolClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(scs => scs.Subject)
                .WithMany(sub => sub.SchoolClassSubjects)
                .HasForeignKey(scs => scs.SubjectId)
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
