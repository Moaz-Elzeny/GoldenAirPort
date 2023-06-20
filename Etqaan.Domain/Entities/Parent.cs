using Etqaan.Domain.Entities.Auth;

namespace Etqaan.Domain.Entities
{
    public class Parent : BaseEntity
    {
        public Parent()
        {
            Students = new HashSet<Student>();
        }
        public string Id { get; set; }
        public string AppUserId { get; set; }
        public string JobTitle { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
