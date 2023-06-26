namespace Etqaan.Domain.Entities
{
    public class GradeSubject : BaseEntity
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
