namespace Etqaan.Domain.Entities
{
    public class AboutStudent
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int AboutId { get; set; }
        public virtual Student Student { get; set; }
        public virtual About About { get; set; }
    }
}
