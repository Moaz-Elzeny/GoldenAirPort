using Etqaan.Domain.Entities.Auth;
using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class Student : BaseEntity
    {
        public Student()
        {
            AboutStudents = new HashSet<AboutStudent>();
            StudentSubjects = new HashSet<StudentSubject>();
            MissionStudents = new HashSet<MissionStudents>();
            StudentGroups = new HashSet<StudentGroup>();
            StudentAnswers = new HashSet<StudentAnswer>();
        }
        public string Id { get; set; }
        public string AppUserId { get; set; }
        public string SchoolId { get; set; }
        public int SchoolGradeId { get; set; }
        public int SchoolClassId { get; set; }
        public StudentCategory StudentCategory { get; set; }
        public LearningSystem LearningSystem { get; set; }
        public string ParentId { get; set; }
        public string StudentIdInSchool { get; set; }
        public StudentAbility StudentAbility { get; set; }
        public Accomodation Accomodation { get; set; }
        public decimal V { get; set; }
        public decimal Q { get; set; }
        public decimal NV { get; set; }
        public decimal S { get; set; }
        public decimal MeanSAS { get; set; }

        public virtual ICollection<AboutStudent> AboutStudents { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual School School { get; set; }
        public virtual SchoolGrade SchoolGrade { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<MissionStudents> MissionStudents { get; set; }
        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }




    }
}


