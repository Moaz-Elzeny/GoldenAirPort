namespace Etqaan.Domain.Entities
{
    public class SchoolClass : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SchoolId { get; set; }
        public int SchoolGradeId { get; set; }
        public virtual School School { get; set; }
        public virtual SchoolGrade SchoolGrade { get; set; }
        public virtual ICollection<Student> Students { get; set; }


    }
}

