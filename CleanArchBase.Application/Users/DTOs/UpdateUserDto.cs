using CleanArchBase.Domain.Enums;

namespace CleanArchBase.Application.Users.DTOs
{
    public sealed record UpdateUserDto
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public string? AddressDetails { get; init; }
        public UserType? UserType { get; init; }
        public bool? Active { get; init; }
    }

}
