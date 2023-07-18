using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.LearningResources.Dtos
{
    public class UpdateLearningResourceDto
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public ResourceFileType ResourceFileType { get; set; }
        public ReourceTargetedCategory ResourceTargetedCategory { get; set; }
        public IFormFile FilePath { get; set; }
        public IFormFile? CoverImagePath { get; set; }
        public int? Size { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
    }
}
