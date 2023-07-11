using Etqaan.Domain.Enums;

namespace Etqaan.Application.Students.DTOs
{
    public record StudentDto
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
        public string ProfilePicture { get; set; }
        public UserType? UserType { get; set; }
        public int? NationalityId { get; set; }
        public string? StudentId { get; set; }
        public string? SchoolId { get; set; }
        public int? SchoolGradeId { get; set; }
        public int? SchoolClassId { get; set; }
        public StudentCategory? StudentCategory { get; set; }
        public LearningSystem? LearningSystem { get; set; }
        public string? ParentId { get; set; }
        public string? StudentIdInSchool { get; set; }
        public StudentAbility? StudentAbility { get; set; }
        public Accomodation? Accomodation { get; set; }
        public decimal? V { get; set; }
        public decimal? Q { get; set; }
        public decimal? NV { get; set; }
        public decimal? S { get; set; }
        public decimal? MeanSAS { get; set; }
        public int TotalPoints { get; set; }
    }
}
