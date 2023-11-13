namespace GoldenAirport.Application.AdminDetails.DTOs
{
    public class AdminDetailsDto
    {
        public CompanyDetailsDto CompanyDetails { get; set; }
        public decimal? ServiceFees { get; set; }
        public byte? TaxValue { get; set; }
        public string? BookingTime { get; set; }
        public string? PrivacyPolicyAndTerms { get; set; }
    }

    public class CompanyDetailsDto
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
