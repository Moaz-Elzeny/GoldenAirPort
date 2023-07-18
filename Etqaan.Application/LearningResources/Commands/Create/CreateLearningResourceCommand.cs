using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Domain.Entities;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.LearningResources.Commands.Create
{
    public class CreateLearningResourceCommand : IRequest<ResultDto<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public ResourceFileType ResourceFileType { get; set; }
        public ReourceTargetedCategory ResourceTargetedCategory { get; set; }
        public IFormFile FilePath { get; set; }
        public IFormFile? CoverImagePath { get; set; }
        public int? Size { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateLearningResourceHandler : IRequestHandler<CreateLearningResourceCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IHostingEnvironment _environment;

            public CreateLearningResourceHandler(IApplicationDbContext context, IHostingEnvironment environment)
            {
                _context = context;
                _environment = environment;
            }

            public async Task<ResultDto<string>> Handle(CreateLearningResourceCommand request, CancellationToken cancellationToken)
            {
                var learningResource = new LearningResource
                {
                    NameAr = request.NameAr,
                    NameEn = request.NameEn,
                    ResourceFileType = request.ResourceFileType,
                    ReourceTargetedCategory = request.ResourceTargetedCategory,
                    SubjectId = request.SubjectId,
                    GradeId = request.GradeId,
                    CreationDate = DateTime.Now,
                    CreatedById = "EtqaanAdmin"
                };
                if (request.CoverImagePath != null) { learningResource.CoverImagePath = await FileHelper.SaveImageAsync(request.CoverImagePath, _environment); }

                if (request.ResourceFileType == ResourceFileType.Video)
                {
                    if (request.FilePath != null) { learningResource.FilePath = FileHelper.SaveVideo(request.FilePath, _environment); }
                }
                else
                {
                    if (request.FilePath != null) { learningResource.FilePath = await FileHelper.SaveFileAsync(request.FilePath, _environment); }
                }
                _context.LearningResources.Add(learningResource);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success(learningResource.Id.ToString());
            }
        }
    }
}
