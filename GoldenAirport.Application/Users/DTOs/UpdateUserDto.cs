using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Users.DTOs
{
    public sealed record UpdateUserDto
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public UserType? UserType { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public int? CountryId { get; set; }
    }

}
