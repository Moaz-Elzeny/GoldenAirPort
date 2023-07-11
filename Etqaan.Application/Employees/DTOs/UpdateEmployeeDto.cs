using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Employees.DTOs
{
    public record UpdateEmployeeDto
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? PhoneNumber { get; init; }
        public DateTime? DateOfBirth { get; init; }
        public Gender? Gender { get; init; }
        public string? NationalIdNumber { get; init; }
        public Religion? Religion { get; init; }
        public string? AddressDetails { get; init; }
        public IFormFile? ProfilePicture { get; init; }
        public UserType? UserType { get; init; }
        public int? NationalityId { get; init; }
        public string? JobTitle { get; init; }
        public byte? YearsOfExperience { get; init; }
        public JobType? JobType { get; init; }
        public decimal? Salary { get; init; }
        public int? BankId { get; init; }
        public string? BankAccountNumber { get; init; }
        public string? IBAN { get; init; }
        public bool? Active { get; init; }
    }

}
