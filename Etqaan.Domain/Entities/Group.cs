namespace Etqaan.Domain.Entities
{
    public class Group : BaseEntity
    {
        public Group()
        {
            StudentGroups = new HashSet<StudentGroup>();
            MissionGroups = new HashSet<MissionGroup>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string? NameEn { get; set; }

        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
        public virtual ICollection<MissionGroup> MissionGroups { get; set; }

    }
}
