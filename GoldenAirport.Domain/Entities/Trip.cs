namespace GoldenAirport.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public Trip() 
        {
            ToCity = new HashSet<CityTrip>();
            TripRegistrations = new HashSet<TripRegistration>();
        
        }   
        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsRefundable { get; set; }
        public decimal Price { get; set; }
        public byte Guests { get; set; }
        public TimeSpan TripHours { get; set;}

        public int FromCityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<CityTrip> ToCity { get; set; }

        public virtual ICollection<TripRegistration> TripRegistrations { get; set; }
    }
}
