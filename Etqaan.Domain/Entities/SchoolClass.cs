namespace Etqaan.Domain.Entities
{
    public class SchoolClass : BaseEntity
    {
        public SchoolClass()
        {
            SchoolClassSubjects = new HashSet<SchoolClassSubject>();
            StudentSubjects = new HashSet<StudentSubject>();
            MissionClasses = new HashSet<MissionClasses>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SchoolId { get; set; }
        public int SchoolGradeId { get; set; }
        public virtual School School { get; set; }
        public virtual SchoolGrade SchoolGrade { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SchoolClassSubject> SchoolClassSubjects { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<MissionClasses> MissionClasses { get; set; }



    }
}

