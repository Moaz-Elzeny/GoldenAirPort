namespace Etqaan.Application.Teachers.DTOs
{
    public record TeachersListDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string SchoolName { get; set; }
        public string SubjectsCount { get; init; }
        public string ClassesCount { get; init; }
        public string Points { get; init; }
        public string Interaction { get; init; } //التفاعل

    }
}
