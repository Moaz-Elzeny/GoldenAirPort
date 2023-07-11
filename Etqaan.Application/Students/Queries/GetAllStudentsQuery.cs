using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.Students.DTOs;
using Etqaan.Domain.Enums;

namespace Etqaan.Application.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<ResultDto<PaginatedList<StudentDto>>>
    {
        public int PageNumber { get; set; }
        public string? SchoolId { get; set; }
        public int? GradeId { get; set; }
        public int? SubjectId { get; set; }
        public Gender? Gender { get; set; }
        public int? NationalityId { get; set; }
        public string? SearchKeyword { get; set; }
        public bool OrderByPointsDesc { get; set; }
    }

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, ResultDto<PaginatedList<StudentDto>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStudentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<PaginatedList<StudentDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = 10;

            var query = _context.Students
                .Where(s => !s.Deleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.SchoolId))
                query = query.Where(s => s.SchoolId == request.SchoolId);

            if (request.GradeId.HasValue)
                query = query.Where(s => s.SchoolGradeId == request.GradeId.Value);

            if (request.SubjectId.HasValue)
                query = query.Where(s => s.StudentSubjects.Any(ss => ss.SubjectId == request.SubjectId.Value));

            if (request.Gender.HasValue)
                query = query.Where(s => s.AppUser.Gender == request.Gender.Value);

            if (request.NationalityId.HasValue)
                query = query.Where(s => s.AppUser.NationalityId == request.NationalityId.Value);

            if (!string.IsNullOrEmpty(request.SearchKeyword))
                query = query.Where(s =>
                    EF.Functions.Like(s.AppUser.FirstName, $"%{request.SearchKeyword}%") ||
                    EF.Functions.Like(s.AppUser.LastName, $"%{request.SearchKeyword}%") ||
                    EF.Functions.Like(s.AppUser.UserName, $"%{request.SearchKeyword}%") ||
                    EF.Functions.Like(s.AppUser.Email, $"%{request.SearchKeyword}%") ||
                    EF.Functions.Like(s.AppUser.PhoneNumber, $"%{request.SearchKeyword}%"));

            if (request.OrderByPointsDesc)
                query = query.OrderByDescending(s => s.AppUser.UserActivities.Sum(a => a.Activity.Points));
            else
                query = query.OrderBy(s => s.AppUser.UserActivities.Sum(a => a.Activity.Points));

            var totalCount = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var students = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(student => new StudentDto
                {
                    StudentId = student.Id,
                    UserName = student.AppUser.UserName,
                    Email = student.AppUser.Email,
                    FirstName = student.AppUser.FirstName,
                    LastName = student.AppUser.LastName,
                    PhoneNumber = student.AppUser.PhoneNumber,
                    DateOfBirth = student.AppUser.DateOfBirth,
                    Gender = student.AppUser.Gender,
                    NationalIdNumber = student.AppUser.NationalIdNumber,
                    Religion = student.AppUser.Religion,
                    AddressDetails = student.AppUser.AddressDetails,
                    ProfilePicture = student.AppUser.ProfilePicture,
                    UserType = student.AppUser.UserType,
                    NationalityId = student.AppUser.NationalityId,
                    SchoolId = student.SchoolId,
                    SchoolGradeId = student.SchoolGradeId,
                    SchoolClassId = student.SchoolClassId,
                    StudentCategory = student.StudentCategory,
                    LearningSystem = student.LearningSystem,
                    ParentId = student.ParentId,
                    StudentIdInSchool = student.StudentIdInSchool,
                    StudentAbility = student.StudentAbility,
                    Accomodation = student.Accomodation,
                    V = student.V,
                    Q = student.Q,
                    NV = student.NV,
                    S = student.S,
                    MeanSAS = student.MeanSAS,
                    TotalPoints = student.AppUser.UserActivities.Sum(a => a.Activity.Points)
                })
                .ToListAsync(cancellationToken);

            var paginatedList = new PaginatedList<StudentDto>
            {
                Items = students,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return ResultDto<PaginatedList<StudentDto>>.Success(paginatedList);
        }
    }
}
