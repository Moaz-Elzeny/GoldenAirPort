using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Schools.DTOs
{
    public class EditSchoolDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? NationalIdNumber { get; set; }
        public Religion? Religion { get; set; }
        public string? AddressDetails { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public UserType? UserType { get; set; }
        public int? NationalityId { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public IFormFile? LogoImage { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public OrganizationType? OrganizationType { get; set; }
        public LearningSystem? LearningSystem { get; set; }
        public int? StudentCapacityId { get; set; }
        public int? TeachersCount { get; set; }
        public int? ClassesCount { get; set; }
        public int? SubscriptionId { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public int? SubscriptionPeriodId { get; set; }
        public decimal? SubscriptionPrice { get; set; }
    }

}
