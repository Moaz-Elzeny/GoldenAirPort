namespace GoldenAirport.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public Trip() 
        {
            ToCity = new HashSet<CityTrip>();
            TripRegistrations = new HashSet<TripRegistration>();
            PaymentOptionTrips = new HashSet<PaymentOptionTrip>();
            WhyVisits  =new HashSet<WhyVisit>();
            WhatAreIncluded = new HashSet<WhatIsIncluded>();
            Restrictions = new HashSet<Restriction>();
            Accessibilities = new HashSet<Accessibility>();
        }   
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsRefundable { get; set; }
        public decimal Price { get; set; }
        public decimal ChildPrice { get; set; }
        public int Guests { get; set; }
        public int RemainingGuests { get; set; }
        public TimeSpan TripHours { get; set;}

        public int FromCityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<CityTrip> ToCity { get; set; }
        public virtual ICollection<TripRegistration> TripRegistrations { get; set; }
        public virtual ICollection<PaymentOptionTrip> PaymentOptionTrips { get; set; }
        public virtual ICollection<WhyVisit> WhyVisits { get; set; }
        public virtual ICollection<WhatIsIncluded> WhatAreIncluded { get; set; }
        public virtual ICollection<Restriction> Restrictions { get; set; }
        public virtual ICollection<Accessibility> Accessibilities { get; set; }
    }
}
