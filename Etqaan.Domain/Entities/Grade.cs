﻿namespace Etqaan.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public Grade()
        {
            SchoolGrades = new HashSet<SchoolGrade>();
            GradeSubjects = new HashSet<GradeSubject>();
            StudentSubjects = new HashSet<StudentSubject>();
            LearningResources = new HashSet<LearningResource>();
            ExternalExams = new HashSet<ExternalExam>();
            Missions = new HashSet<Mission>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<SchoolGrade> SchoolGrades { get; set; }
        public virtual ICollection<GradeSubject> GradeSubjects { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<LearningResource> LearningResources { get; set; }
        public virtual ICollection<ExternalExam> ExternalExams { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }

    }
}
