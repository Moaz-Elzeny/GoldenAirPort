using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Users.DTOs
{
    public record UserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public string ProfilePicture { get; set; }
        public int? CountryId { get; set; }
    }



}
