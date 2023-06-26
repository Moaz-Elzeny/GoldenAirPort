namespace Etqaan.Domain.Entities
{
    public class MissionClasses
    {
        public int Id { get; set; }
        public int SchoolClassId { get; set; }
        public int MissionId { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        public virtual Mission Mission { get; set; }
    }
}