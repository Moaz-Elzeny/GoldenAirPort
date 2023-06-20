using Etqaan.Domain.Entities.Auth;

namespace Etqaan.Domain.Entities
{
    public class UserActivity
    {
        public int Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public string AppUserId { get; set; }
        public int ActivityId { get; set; }
        public TimeSpan Duration { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
