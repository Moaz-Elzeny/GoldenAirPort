using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class Chat : BaseEntity
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public string? EmployeeId { get; set; }
        public virtual AppUser Admin { get; set; }
        public virtual AppUser Employee { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set;}
    }
}
