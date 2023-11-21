using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Domain.Entities
{
    public class Package : BaseEntity
    {
        public Package() 
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsRefundable { get; set; }
        public decimal Price { get; set; }
        public decimal ChildPrice { get; set; }
        public int Guests { get; set; }
        public int RemainingGuests { get; set; }
        public string AboutExploreTour { get; set; }

        public int FromCityId { get; set; }
        public virtual City City { get; set; }
        public int? ToCityId { get; set; }
        public virtual City ToCity { get; set; }

        public virtual ICollection<PackagePlan> PackagePlans { get; set; }
        public virtual ICollection<PackageRegistration> PackageRegistrations { get; set; }
        //public virtual ICollection<PackageRegistrationEditing> PackageRegistrationsEditing { get; set; }
        public virtual ICollection<PaymentOptionPackage> PaymentOptionPackages { get; set; }


    }
}
