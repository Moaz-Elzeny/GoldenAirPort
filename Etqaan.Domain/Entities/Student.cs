using Etqaan.Domain.Entities.Auth;

namespace Etqaan.Domain.Entities
{
    public class Student : BaseEntity
    {
        public Student()
        {
            AboutStudents = new HashSet<AboutStudent>();
        }
        public string Id { get; set; }
        public string AppUserId { get; set; }
        public string SchoolId { get; set; }
        public int GradeId { get; set; }
        public int SchoolClassId { get; set; }
        public int StudentCategory { get; set; }//
        public int LearningSystem { get; set; }//
        public string ParentId { get; set; }
        public string StudentIdInSchool { get; set; }
        public string StudentAbility { get; set; }
        public string Accomodation { get; set; }
        public decimal V { get; set; }
        public decimal Q { get; set; }
        public decimal NV { get; set; }
        public decimal S { get; set; }
        public decimal MeanSAS { get; set; }

        public virtual ICollection<AboutStudent> AboutStudents { get; set; }
        public virtual AppUser AppUser { get; set; }


    }
}


