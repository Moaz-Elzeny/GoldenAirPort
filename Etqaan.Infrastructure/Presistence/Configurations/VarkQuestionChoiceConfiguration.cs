using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Domain.Entities
{
    public class VarkQuestionChoiceConfiguration : IEntityTypeConfiguration<VarkQuestionChoice>
    {
        public void Configure(EntityTypeBuilder<VarkQuestionChoice> builder)
        {
            builder.ToTable("VarkQuestionChoices");
            builder.HasKey(choice => choice.Id);
            builder.Property(choice => choice.Text).HasMaxLength(500).IsRequired();
            builder.Property(choice => choice.VarkScore);

        }
    }
}
