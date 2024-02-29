using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Flights.DTOs
{
    public class AdultFlightDto
    {
        public Title? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PassportNo { get; set; }
        public string? IssuingCountry { get; set; }
        public DateTime? PassportIssuance { get; set; }
        public DateTime? PassportExpairy { get; set; }
        public string? Nationality { get; set; }
        public string? IDNumber { get; set; }

    }
}
