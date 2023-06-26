namespace Etqaan.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public Skill()
        {
            Axes = new HashSet<Axis>();

            ExternalExamSkills = new HashSet<ExternalExamSkills>();
            MissionSkills = new HashSet<MissionSkills>();
            QuestionSkills = new HashSet<QuestionSkill>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string? NameEn { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Axis> Axes { get; set; }
        public virtual ICollection<ExternalExamSkills> ExternalExamSkills { get; set; }
        public virtual ICollection<MissionSkills> MissionSkills { get; set; }
        public virtual ICollection<QuestionSkill> QuestionSkills { get; set; }

    }
}