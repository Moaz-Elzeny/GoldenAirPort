namespace GoldenAirport.Domain.Entities
{
    public class PaymentOption
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<PaymentOptionPackage> PaymentOptionPackages { get; set; }
        public virtual ICollection<PaymentOptionTrip> PaymentOptionTrips { get; set; }

       
    }
}
