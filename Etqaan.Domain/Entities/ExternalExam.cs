using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class ExternalExam : BaseEntity
    {
        public ExternalExam()
        {
            ExternalExamSkills = new HashSet<ExternalExamSkills>();
            Questions = new HashSet<Question>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string? NameEn { get; set; }

        public ExamType ExamType { get; set; }
        public bool NotifyParentAndStudent { get; set; }
        public bool CanShowResult { get; set; }
        public TimeSpan Duration { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public virtual ICollection<ExternalExamSkills> ExternalExamSkills { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}

