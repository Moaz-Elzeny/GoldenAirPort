using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Dtos
{
    public class UpdateTripRegistrationDto
    {
       
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public Title? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AdultPassportNo { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? ChildPassportNo { get; set; }
        public AgeRange? AgeRange { get; set; }
        public int? TripId { get; set; }
        public int? NoOfAdults { get; set; } = 1;
    }
}
