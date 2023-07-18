namespace Etqaan.Application.SchoolClasses.DTOs
{

    public record GradeClassesDto
    {
        public string GradeName { get; set; }
        public int ClassesCount { get; set; }
        public List<SchoolClassDto> SchoolClasses { get; set; }
    }
    public record SchoolClassDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string SchoolId { get; init; }
        public int SchoolGradeId { get; init; }
        public string SubjectsCount { get; init; }
    }


}
