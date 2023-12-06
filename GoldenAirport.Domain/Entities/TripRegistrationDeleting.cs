namespace GoldenAirport.Domain.Entities
{
    public class TripRegistrationDeleting : BaseEntity2
    {
        public int Id { get; set; }

        public int TripRegistrationId { get; set; }
        public virtual TripRegistration TripRegistration { get; set; }
    }
}
