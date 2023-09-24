namespace GoldenAirport.Domain.Entities
{
    public class Balance : BaseEntity2
    {
        public int Id { get; set; }
        public decimal BalanceAmount { get; set; }

        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

       
    }
}
