namespace GoldenAirport.Domain.Entities
{
    public class PaymentOptionPackage
    {
        public int Id { get; set; }

        public int PaymentOptionId { get; set; }
        public virtual PaymentOption PaymentOptions { get; set; }

        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
