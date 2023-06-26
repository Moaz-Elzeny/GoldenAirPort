namespace Etqaan.Domain.Entities
{
    public class MissionSkills
    {
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int SkillId { get; set; }
        public virtual Mission Mission { get; set; }
        public virtual Skill Skill { get; set; }
    }
}