using Etqaan.Domain.Entities.Auth;

namespace Etqaan.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public Teacher()
        {
            TeacherSubjects = new HashSet<TeacherSubject>();
        }
        public string Id { get; set; }
        public byte YearsOfExperience { get; set; }
        public string AppUserId { get; set; }

        public string SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
