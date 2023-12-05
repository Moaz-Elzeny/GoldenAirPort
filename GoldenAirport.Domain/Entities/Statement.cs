namespace GoldenAirport.Domain.Entities
{
    public class Statement : BaseEntity2
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
