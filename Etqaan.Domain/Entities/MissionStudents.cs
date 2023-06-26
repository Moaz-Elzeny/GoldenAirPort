namespace Etqaan.Domain.Entities
{
    public class MissionStudents
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int MissionId { get; set; }
        public virtual Mission Mission { get; set; }
        public virtual Student Student { get; set; }
    }
}