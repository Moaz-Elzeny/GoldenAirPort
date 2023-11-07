namespace GoldenAirport.Application.AdminDetails.DTOs
{
    public class AdminDetailsDto
    {
        public decimal? ServiceFees { get; set; }
        public byte? TaxValue { get; set; }
        public TimeSpan? BookingTime { get; set; }
        public string? PrivacyPolicyAndTerms { get; set; }
    }
}
