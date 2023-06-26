namespace Etqaan.Domain.Entities
{
    public class ExternalExamSkills
    {
        public int Id { get; set; }
        public int ExternalExamId { get; set; }
        public int SkillId { get; set; }
        public virtual ExternalExam ExternalExam { get; set; }
        public virtual Skill Skill { get; set; }

    }
}
