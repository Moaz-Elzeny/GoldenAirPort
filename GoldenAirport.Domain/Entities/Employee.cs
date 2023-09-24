using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Id { get; set; }
        public int AgentCode { get; set; }
        public decimal Target { get; set; }
        public DateTime LastLogin { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public decimal BalanceId { get; set; }
        public virtual Balance Balance { get; set; }

        public virtual ICollection<DailyGoal> DailyGoals { get; set; }
        public virtual ICollection<PaymentOption> PaymentOptions { get; set; }

    }
}
