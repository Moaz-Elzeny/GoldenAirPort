using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Users.DTOs
{
    public sealed record UpdateUserDto
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public decimal? ServiceFees { get; set; }
        public int? TaxValue { get; set; }
        public int? BookingTime { get; set; }
        public UserType? UserType { get; init; }
        public string? PrivacyPolicyAndTerms { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public string? CurrentPassword { get; init; }
        //public bool? Active { get; init; }
        public string? NewPassword { get; init; }
    }

}
