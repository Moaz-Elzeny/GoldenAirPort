namespace Etqaan.Domain.Entities
{
    public class StudentSubject : BaseEntity
    {
        public int Id { get; set; }
        public int SchoolClassId { get; set; }
        public int GradeId { get; set; }
        public string StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
