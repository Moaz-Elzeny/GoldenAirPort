using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Domain.Entities.Auth
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }
        public decimal ServiceFees { get; set; }
        public int AgentCode { get; set; }
        public decimal Balance { get; set; }
        public decimal DailyGoal { get; set; }
        public paymentMethod PaymentMethod { get; set; }
        public DateTime LastLogin { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
