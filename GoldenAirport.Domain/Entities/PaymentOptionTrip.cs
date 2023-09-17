namespace GoldenAirport.Domain.Entities
{
    public class PaymentOptionTrip
    {
        public int Id { get; set; }

        public int PaymentOptionId { get; set; }
        public virtual PaymentOption PaymentOptions { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
