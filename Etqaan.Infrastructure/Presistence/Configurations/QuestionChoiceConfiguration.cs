using Etqaan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Infrastructure.Persistence.Configurations
{
    public class QuestionChoiceConfiguration : IEntityTypeConfiguration<QuestionChoice>
    {
        public void Configure(EntityTypeBuilder<QuestionChoice> builder)
        {
            builder.ToTable("QuestionChoices");

            builder.HasKey(qc => qc.Id);

            builder.Property(qc => qc.Id)
                .IsRequired();

            builder.Property(qc => qc.ChoiceText)
                .HasMaxLength(256);

            builder.Property(qc => qc.SortIndex)
                .IsRequired();

            builder.Property(qc => qc.ImageIcon)
                .HasMaxLength(256);

            builder.Property(qc => qc.IsCorrect)
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
