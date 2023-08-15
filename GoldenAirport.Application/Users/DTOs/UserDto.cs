using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Users.DTOs
{
    public record UserDto
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public decimal ServiceFees { get; set; }
        public UserType UserType { get; init; }
        public string ProfilePicture { get; set; }
        //public bool Deleted { get; init; }
        //public bool Active { get; init; }
        //public string CreatedById { get; init; }
        //public DateTime CreationDate { get; init; }
        //public string? ModifiedById { get; init; }
        //public DateTime? ModificationDate { get; init; }
    }



}
