namespace Etqaan.Domain.Entities
{
    public class StudentGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string StudentId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
