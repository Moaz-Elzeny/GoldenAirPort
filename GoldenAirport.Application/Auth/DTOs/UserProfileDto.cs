using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Auth.DTOs
{
    public record UserProfileDto
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public decimal ServiceFees { get; set; }
        public string ProfilePicture { get; set; }
        public UserType UserType { get; init; }
    }
}
