namespace Etqaan.Domain.Entities
{
    public class SchoolGrade
    {
        public int Id { get; set; }
        public string SchoolId { get; set; }
        public string GradeId { get; set; }
        public virtual School School { get; set; }
        public virtual Grade Grade { get; set; }

    }
}