using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.Teachers.DTOs;
using System.Globalization;

namespace Etqaan.Application.Teachers.Queries
{
    public class GetAllTeachersQuery : IRequest<ResultDto<PaginatedList<TeachersListDto>>>
    {
        public string? SchoolId { get; set; }
        public int? SubjectId { get; set; }
        public int? GradeId { get; set; }
        public bool OrderByPointsAscending { get; set; }
        public string? SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, ResultDto<PaginatedList<TeachersListDto>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeachersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<PaginatedList<TeachersListDto>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = request.PageSize <= 0 ? 10 : request.PageSize;

            var query = _context.Teachers.AsQueryable();

            if (!string.IsNullOrEmpty(request.SchoolId))
            {
                query = query.Where(t => t.SchoolId == request.SchoolId);
            }

            if (request.SubjectId.HasValue)
            {
                query = query.Where(t => t.TeacherSubjects.Any(ts => (ts.Subject.GradeSubjects.Select(a => a.SubjectId).FirstOrDefault()) == request.SubjectId));
            }

            if (request.GradeId.HasValue)
            {
                query = query.Where(t => t.TeacherSubjects.Any(ts => ts.Subject.GradeSubjects.Select(a => a.GradeId).FirstOrDefault() == request.GradeId));
            }

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                query = query.Where(t =>
                    t.AppUser.FirstName.Contains(request.SearchKey) ||
                    t.AppUser.LastName.Contains(request.SearchKey) ||
                    t.AppUser.UserName.Contains(request.SearchKey));
            }

            if (request.OrderByPointsAscending)
            {
                query = query.OrderBy(t => t.AppUser.UserActivities.Sum(a => a.Activity.Points));
            }
            else
            {
                query = query.OrderByDescending(t => t.AppUser.UserActivities.Sum(a => a.Activity.Points));
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var teachers = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(teacher => new TeachersListDto
                {
                    Id = teacher.Id,
                    Name = $"{teacher.AppUser.FirstName} {teacher.AppUser.LastName}",
                    SchoolName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? teacher.School.NameAr : teacher.School.NameEn,
                    SubjectsCount = teacher.TeacherSubjects.Count.ToString(),
                    ClassesCount = _context.SchoolClassSubjects
                               .Where(scs => scs.Subject.TeacherSubjects.Any(ts => ts.TeacherId == teacher.Id))
                               .Select(scs => scs.SchoolClassId)
                               .Distinct()
                               .Count()
                               .ToString(),
                    Points = teacher.AppUser.UserActivities.Sum(a => a.Activity.Points).ToString(),
                    Interaction = new Random().Next(10, 50).ToString(),
                })
                .ToListAsync(cancellationToken);

            var paginatedList = new PaginatedList<TeachersListDto>
            {
                Items = teachers,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return ResultDto<PaginatedList<TeachersListDto>>.Success(paginatedList);
        }


    }

}
