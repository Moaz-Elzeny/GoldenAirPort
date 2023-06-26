using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etqaan.Domain.Entities
{
    public class VarkQuestionConfiguration : IEntityTypeConfiguration<VarkQuestion>
    {
        public void Configure(EntityTypeBuilder<VarkQuestion> builder)
        {
            builder.ToTable("VarkQuestions");
            builder.HasKey(q => q.Id);
            builder.Property(q => q.QuestionHead).IsRequired();


            builder.HasOne(q => q.VarkExam)
                .WithMany(exam => exam.VarkQuestions)
                .HasForeignKey(q => q.VarkExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.VarkQuestionChoices)
                .WithOne(choice => choice.VarkQuestion)
                .HasForeignKey(choice => choice.VarkQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
