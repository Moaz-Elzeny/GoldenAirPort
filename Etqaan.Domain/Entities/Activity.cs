using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public UserType UserType { get; set; }
        public virtual ICollection<UserActivity> UserActivities { get; set; }
    }
}
