using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Dtos
{
    public class AdultDto
    {
        public Title? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AdultPassportNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
