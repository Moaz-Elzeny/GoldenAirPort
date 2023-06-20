namespace Etqaan.Domain.Entities
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SchoolId { get; set; }
        public int GradeId { get; set; }
        public virtual School School { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<Student> Students { get; set; }


    }
}


/*

- List<StudentsCategory>


 
 */