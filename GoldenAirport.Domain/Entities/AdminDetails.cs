using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class AdminDetails : BaseEntity2
    {
        public AdminDetails() { }
        public int Id { get; set; }
        public decimal? ServiceFees { get; set; }
        public byte? TaxValue { get; set; }
        public TimeSpan? BookingTime { get; set; }
        public string? PrivacyPolicyAndTerms { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; } 
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
