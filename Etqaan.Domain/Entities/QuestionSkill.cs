namespace Etqaan.Domain.Entities
{
    public class QuestionSkill
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SkillId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
