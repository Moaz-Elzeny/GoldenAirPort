namespace Etqaan.Domain.Entities
{
    public class SchoolClassSubject : BaseEntity
    {
        public int Id { get; set; }
        public int SchoolClassId { get; set; }
        public int SubjectId { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
