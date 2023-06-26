namespace Etqaan.Domain.Entities
{
    public class TeacherSubject : BaseEntity
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public int SubjectId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
