namespace GoldenAirport.Domain.Entities
{
    public class PaymentOptionEmployee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int PaymentOptionId { get; set; }
        public bool Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PaymentOption PaymentOption { get; set; }
    }
}
