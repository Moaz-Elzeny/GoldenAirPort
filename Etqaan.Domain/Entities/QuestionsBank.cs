using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class QuestionsBank : BaseEntity
    {
        public QuestionsBank()
        {
            Skills = new HashSet<Skill>();
            Questions = new HashSet<Question>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string? NameEn { get; set; }
        public QuestionsBankType QuestionsBankType { get; set; }
        public int SubjectId { get; set; }
        public StudentCategory StudentCategory { get; set; }
        public int GradeId { get; set; }
        public ExamType ExamType { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
