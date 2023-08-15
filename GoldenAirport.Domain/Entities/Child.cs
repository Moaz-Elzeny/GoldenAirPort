using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Domain.Entities
{
    public class Child : BaseEntity
    {
        public int Id { get; set; }
        public string? PassportNo { get; set; }
        public AgeRange AgeRange { get; set; }
        public int TripRegistrationId { get; set; }
        public virtual TripRegistration TripRegistration { get; set; }

    }
}
