namespace Etqaan.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public Subject()
        {
            GradeSubjects = new HashSet<GradeSubject>();
            SchoolClassSubjects = new HashSet<SchoolClassSubject>();
            StudentSubjects = new HashSet<StudentSubject>();
            LearningResources = new HashSet<LearningResource>();
            TeacherSubjects = new HashSet<TeacherSubject>();
            Skills = new HashSet<Skill>();
            ExternalExams = new HashSet<ExternalExam>();
            Missions = new HashSet<Mission>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<GradeSubject> GradeSubjects { get; set; }
        public virtual ICollection<SchoolClassSubject> SchoolClassSubjects { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<LearningResource> LearningResources { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<ExternalExam> ExternalExams { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
