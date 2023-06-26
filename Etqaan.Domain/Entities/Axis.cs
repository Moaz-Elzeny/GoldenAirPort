namespace Etqaan.Domain.Entities
{
    public class Axis : BaseEntity
    {
        public Axis()
        {
            Standards = new HashSet<Standard>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string? NameEn { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual ICollection<Standard> Standards { get; set; }
    }
}

