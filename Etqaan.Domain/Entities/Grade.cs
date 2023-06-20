namespace Etqaan.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public Grade()
        {
            SchoolClasses = new HashSet<SchoolClass>();
            SchoolGrades = new HashSet<SchoolGrade>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
        public virtual ICollection<SchoolGrade> SchoolGrades { get; set; }
    }
}
