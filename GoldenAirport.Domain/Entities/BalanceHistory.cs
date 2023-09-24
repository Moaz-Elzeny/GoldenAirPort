namespace GoldenAirport.Domain.Entities
{
    public class BalanceHistory : BaseEntity2
    {
        public int Id { get; set; }
        public decimal TransactionAmount { get; set; }
        public int BalanceId { get; set; }
        public virtual Balance Balance { get; set; }
    }
}
