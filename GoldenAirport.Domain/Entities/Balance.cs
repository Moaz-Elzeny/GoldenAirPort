using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class Balance : BaseEntity2
    {
        public int Id { get; set; }
        public decimal TransactionAmount { get; set; }
        //public int BalanceId { get; set; }
        public decimal BalanceAmount { get; set; }

        public string? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
