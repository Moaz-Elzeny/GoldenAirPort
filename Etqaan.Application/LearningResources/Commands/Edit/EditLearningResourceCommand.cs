using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Domain.Entities;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.LearningResources.Commands.Edit
{
    public class EditLearningResourceCommand : IRequest<ResultDto<string>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public ResourceFileType ResourceFileType { get; set; }
        public ReourceTargetedCategory ResourceTargetedCategory { get; set; }
        public IFormFile FilePath { get; set; }
        public IFormFile? CoverImagePath { get; set; }
        public int? Size { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditLearningResourceHandler : IRequestHandler<EditLearningResourceCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _Context;
            private readonly IHostingEnvironment _environment;

            public EditLearningResourceHandler(IApplicationDbContext context, IMediator mediator, IHostingEnvironment environment)
            {
                _Context = context;
                _environment = environment;
            }
            public async Task<ResultDto<string>> Handle(EditLearningResourceCommand request, CancellationToken cancellationToken)
            {
                var learningResource = await _Context.LearningResources.FindAsync(request.Id);
                if (learningResource == null)
                {
                    return ResultDto<string>.Failure("Resource not found.");
                }
                learningResource.ModifiedById = request.CurrentUserId;
                learningResource.ModificationDate = DateTime.Now;

                if (request.NameAr != null)
                    learningResource.NameAr = request.NameAr;

                if (request.NameEn != null)
                    learningResource.NameEn = request.NameEn;

                if (request.NameAr != null)
                    learningResource.NameAr = request.NameAr;

                if (request.ResourceFileType != null)
                    learningResource.ResourceFileType = request.ResourceFileType;

                if (request.ResourceTargetedCategory != null)
                    learningResource.ReourceTargetedCategory = request.ResourceTargetedCategory;

                if (request.SubjectId != null)
                    learningResource.SubjectId = request.SubjectId;

                if (request.GradeId != null)
                    learningResource.GradeId = request.GradeId;

                if (request.CoverImagePath != null)
                {
                    if (!string.IsNullOrEmpty(learningResource.CoverImagePath))
                    {
                        FileHelper.DeleteFile(learningResource.CoverImagePath, _environment);
                    }

                    learningResource.CoverImagePath = await FileHelper.SaveImageAsync(request.CoverImagePath, _environment);
                }

                if (request.ResourceFileType == ResourceFileType.Video)
                {
                    if (request.FilePath != null)
                    {
                        if (!string.IsNullOrEmpty(learningResource.FilePath))
                        {
                            FileHelper.DeleteFile(learningResource.FilePath, _environment);
                        }

                        learningResource.FilePath = FileHelper.SaveVideo(request.FilePath, _environment);
                    }
                }
                else
                {
                    if (request.FilePath != null)
                    {
                        if (!string.IsNullOrEmpty(learningResource.FilePath))
                        {
                            FileHelper.DeleteFile(learningResource.FilePath, _environment);
                        }

                        learningResource.FilePath = await FileHelper.SaveFileAsync(request.FilePath, _environment);
                    }
                }
                await _Context.SaveChangesAsync(cancellationToken);
                return ResultDto<string>.Success("Learning Resource Updated Successfully!");
            }
        }
    }
}
