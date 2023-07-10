using Etqaan.Domain.Enums;

namespace Etqaan.Application.Auth.DTOs
{
    public record UserProfileDto
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public DateTime? DateOfBirth { get; init; }
        public Gender? Gender { get; init; }
        public string NationalIdNumber { get; init; }
        public Religion? Religion { get; init; }
        public string AddressDetails { get; init; }
        public string ProfilePictureUrl { get; init; }
        public UserType UserType { get; init; }
        public int NationalityId { get; init; }
    }
}
