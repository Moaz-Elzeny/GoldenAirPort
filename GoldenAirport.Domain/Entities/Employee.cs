using GoldenAirport.Domain.Entities.Auth;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Id { get; set; }
        public int AgentCode { get; set; }
        public decimal Balance { get; set; }
        public decimal DailyGoal { get; set; }
        public paymentMethod PaymentMethod { get; set; }
        public DateTime LastLogin { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
