namespace Etqaan.Application.SchoolClasses.DTOs
{
    public record EditSchoolClassDto
    {
        public string SchoolId { get; init; }
        public string NameAr { get; init; }
        public string NameEn { get; init; }
        public int? SchoolGradeId { get; init; }
        public List<int> SubjectIds { get; init; }
    }

}
