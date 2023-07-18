using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.SchoolClasses.DTOs;
using System.Globalization;
public class GetAllSchoolClassesQuery : IRequest<ResultDto<PaginatedList<GradeClassesDto>>>
{
    public int PageNumber { get; set; }
    public string? SearchKey { get; set; }
    public string? SchoolId { get; set; }
    public int? SchoolGradeId { get; set; }
    public int? SubjectId { get; set; }
}

public class GetAllSchoolClassesQueryHandler : IRequestHandler<GetAllSchoolClassesQuery, ResultDto<PaginatedList<GradeClassesDto>>>
{
    private readonly IApplicationDbContext _context;

    public GetAllSchoolClassesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto<PaginatedList<GradeClassesDto>>> Handle(GetAllSchoolClassesQuery request, CancellationToken cancellationToken)
    {
        var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
        var pageSize = 10;

        var query = _context.SchoolGrades
            .Include(sg => sg.Grade)
            .Include(sg => sg.School)
            .ThenInclude(sg => sg.SchoolClasses)
            .ThenInclude(sc => sc.SchoolClassSubjects)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.SchoolId))
        {
            query = query.Where(sg => sg.SchoolId == request.SchoolId);
        }

        if (request.SchoolGradeId.HasValue)
        {
            query = query.Where(sg => sg.GradeId == request.SchoolGradeId.Value);
        }

        if (request.SubjectId.HasValue)
        {
            query = query.Where(sg => sg.School.SchoolClasses.Any(sc => sc.SchoolClassSubjects.Any(scs => scs.SubjectId == request.SubjectId.Value)));
        }

        var totalCount = await query.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var gradeClasses = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(sg => new GradeClassesDto
            {
                GradeName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? sg.Grade.NameAr : sg.Grade.NameEn,
                ClassesCount = sg.School.SchoolClasses.Where(a => a.SchoolGrade.GradeId == sg.GradeId).Count(),
                SchoolClasses = sg.School.SchoolClasses
                    .Select(sc => new SchoolClassDto
                    {
                        Id = sc.Id,
                        Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? sc.NameAr : sc.NameEn,
                        SchoolId = sc.SchoolId,
                        SchoolGradeId = sc.SchoolGradeId,
                        SubjectsCount = sc.SchoolClassSubjects.Count.ToString()
                    })
                    .ToList()
            })
            .ToListAsync(cancellationToken);

        var paginatedList = new PaginatedList<GradeClassesDto>
        {
            Items = gradeClasses,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = totalPages
        };

        return ResultDto<PaginatedList<GradeClassesDto>>.Success(paginatedList);
    }
}

