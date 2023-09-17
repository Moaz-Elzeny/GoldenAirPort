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
        //public decimal PriceLessThan12YearsOld { get; set; }
        //public paymentMethod PaymentMethod { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int FromCityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<PackagePlan> PackagePlans { get; set; }
        public virtual ICollection<CityPackage> ToCity { get; set; }
        public virtual ICollection<PaymentOptionPackage> PaymentOptionPackages { get; set; }


    }
}
