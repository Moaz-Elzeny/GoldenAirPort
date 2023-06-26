using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class Mission : BaseEntity
    {
        public Mission()
        {
            MissionSkills = new HashSet<MissionSkills>();
            MissionClasses = new HashSet<MissionClasses>();
            MissionStudents = new HashSet<MissionStudents>();
            MissionGroups = new HashSet<MissionGroup>();
            Questions = new HashSet<Question>();


        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string? NameEn { get; set; }
        public MissionType MissionType { get; set; }

        public StudentCategory StudentCategory { get; set; }

        public ExamType ExamType { get; set; }
        public bool NotifyParentAndStudent { get; set; }
        public bool CanShowResult { get; set; }
        public string Password { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int SubjectId { get; set; }
        public int GradeId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ICollection<MissionSkills> MissionSkills { get; set; }
        public virtual ICollection<MissionClasses> MissionClasses { get; set; }
        public virtual ICollection<MissionStudents> MissionStudents { get; set; }
        public virtual ICollection<MissionGroup> MissionGroups { get; set; }
        public virtual ICollection<Question> Questions { get; set; }



    }
}

