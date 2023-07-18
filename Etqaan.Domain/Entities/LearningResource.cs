using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class LearningResource : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public ResourceFileType ResourceFileType { get; set; }
        public ReourceTargetedCategory ReourceTargetedCategory { get; set; }
        public string FilePath { get; set; }
        public string? CoverImagePath { get; set; }
        public string? Size { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Grade Grade { get; set; }

    }
}
