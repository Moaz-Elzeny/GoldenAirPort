namespace Etqaan.Domain.Entities
{
    public class MissionGroup
    {
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int GroupId { get; set; }
        public virtual Mission Mission { get; set; }
        public virtual Group Group { get; set; }
    }
}