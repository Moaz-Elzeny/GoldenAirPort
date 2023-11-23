using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Dtos
{
    public class UpdateTripRegistrationDto
    {
       
        public int? TripId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<AdultDto> Adult { get; set; }
        public List<ChildDto> Child { get; set; }
    }
}
