using Etqaan.Domain.Enums;

namespace Etqaan.Application.Users.DTOs
{
    public record UserDto
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime? DateOfBirth { get; init; }
        public Gender Gender { get; init; }
        public string NationalIdNumber { get; init; }
        public Religion Religion { get; init; }
        public string? AddressDetails { get; init; }
        public string? ProfilePicture { get; init; }
        public UserType UserType { get; init; }
        public int NationalityId { get; init; }
        public bool Deleted { get; init; }
        public bool Active { get; init; }
        public string CreatedById { get; init; }
        public DateTime CreationDate { get; init; }
        public string? ModifiedById { get; init; }
        public DateTime? ModificationDate { get; init; }
    }



}
