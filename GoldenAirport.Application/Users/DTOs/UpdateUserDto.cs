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
        public UserType? UserType { get; init; }
        //public bool? Active { get; init; }
        public IFormFile? ProfilePicture { get; set; }
    }

}
