using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class AdminDetails : BaseEntity2
    {
        public AdminDetails() { }
        public int Id { get; set; }
        public decimal? ServiceFees { get; set; }
        public byte? TaxValue { get; set; }
        public byte BookingTime { get; set; }
        public string? PrivacyPolicyAndTerms { get; set; }

        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
