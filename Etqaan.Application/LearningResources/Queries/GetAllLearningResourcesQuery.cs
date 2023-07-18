using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.LearningResources.Dtos;
using Etqaan.Application.SchoolClasses.DTOs;
using Etqaan.Domain.Enums;
using System.Globalization;

namespace Etqaan.Application.LearningResources.Queries
{
    public class GetAllLearningResourcesQuery : IRequest<ResultDto<PaginatedList<LearningResourceDto>>>
    {
        public int PageNumber { get; set; }
        public string? SearchText { get; set; }
        public ResourceFileType? ResourceFileType { get; set; }
        public ReourceTargetedCategory? ResourceTargetedCategory { get; set; }
        public int? SubjectId { get; set; }
        public int? GradeId { get; set; }

    }
    public class GetAllLearningResourcesHandler : IRequestHandler<GetAllLearningResourcesQuery, ResultDto<PaginatedList<LearningResourceDto>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllLearningResourcesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<PaginatedList<LearningResourceDto>>> Handle(GetAllLearningResourcesQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = 10;

            var query = _context.LearningResources
                .Include(lr => lr.Grade)
                .Include(lr => lr.Subject)
                .AsQueryable();


            if (!string.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(lr =>
                    lr.NameAr.Contains(request.SearchText) ||
                    lr.NameEn.Contains(request.SearchText));
            }

            if (request.ResourceFileType.HasValue)
            {
                query = query.Where(lr => lr.ResourceFileType == request.ResourceFileType.Value);
            }

            if (request.ResourceTargetedCategory.HasValue)
            {
                query = query.Where(lr => lr.ReourceTargetedCategory == request.ResourceTargetedCategory.Value);
            }

            if (request.SubjectId.HasValue)
            {
                query = query.Where(lr => lr.SubjectId == request.SubjectId.Value);
            }

            if (request.GradeId.HasValue)
            {
                query = query.Where(lr => lr.GradeId == request.GradeId.Value);
            }


            var totalCount = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var learnResources = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(lr => new LearningResourceDto
                {
                    Id = lr.Id,
                    Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? lr.NameEn : lr.NameEn,
                    CoverImagePath = lr.CoverImagePath,
                    FilePath = lr.FilePath,

                }).ToListAsync(cancellationToken);

            var paginatedList = new PaginatedList<LearningResourceDto>
            {
                Items = learnResources,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
            return ResultDto<PaginatedList<LearningResourceDto>>.Success(paginatedList);
        }
    }

}
