namespace GoldenAirport.Domain.Entities
{
    public class PaymentOption
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool Status { get; set; }
        //public string? EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }

        public virtual ICollection<PaymentOptionPackage> PaymentOptionPackages { get; set; }
        public virtual ICollection<PaymentOptionTrip> PaymentOptionTrips { get; set; }
        public virtual ICollection<PaymentOptionEmployee> PaymentOptionEmployees { get; set; }

       
    }
}
