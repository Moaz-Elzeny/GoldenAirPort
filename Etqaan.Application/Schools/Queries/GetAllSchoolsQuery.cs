using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.Schools.DTOs;
using Etqaan.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace Etqaan.Application.Schools.Queries
{
    public class GetAllSchoolsQuery : IRequest<ResultDto<PaginatedList<SchoolsListDto>>>
    {
        public int PageNumber { get; set; }
        public string? SearchText { get; set; }
        public OrganizationType? SchoolType { get; set; }
        public LearningSystem? LearningSystem { get; set; }
        public string? Subscription { get; set; }
    }

    public class GetAllSchoolsQueryHandler : IRequestHandler<GetAllSchoolsQuery, ResultDto<PaginatedList<SchoolsListDto>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSchoolsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<PaginatedList<SchoolsListDto>>> Handle(GetAllSchoolsQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = 10;

            var query = _context.Schools
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(s =>
                    s.NameAr.Contains(request.SearchText) ||
                    s.NameEn.Contains(request.SearchText));
            }

            if (request.SchoolType.HasValue)
            {
                query = query.Where(s => s.OrganizationType == request.SchoolType.Value);
            }

            if (request.LearningSystem.HasValue)
            {
                query = query.Where(s => s.LearningSystem == request.LearningSystem.Value);
            }

            if (!request.Subscription.IsNullOrEmpty())
            {
                query = query.Where(s => s.Subscription.NameEn == request.Subscription || s.Subscription.NameAr == request.Subscription);
            }



            var totalCount = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var schools = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(school => new SchoolsListDto
                {
                    Id = school.Id,
                    Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? school.NameAr : school.NameEn,
                    Logo = school.LogoImage,
                    Country = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? school.Country.NameAr : school.Country.NameEn,
                    City = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? school.City.NameAr : school.City.NameEn,
                    LearningSystem = EnumHelper.GetEnumLocalizedDescription(school.LearningSystem),
                    StudentsCount = school.Students.Count.ToString(),
                    TeachersCount = school.Teachers.Count.ToString(),
                    ClassesCount = school.SchoolClasses.Count.ToString(),
                    SubjectsCount = new Random().Next(10, 50).ToString(),
                    AchievmentLevel = new Random().Next(10, 50).ToString(),
                    ProgressDegree = new Random().Next(10, 50).ToString(),
                    SubscriptionType = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? school.Subscription.NameAr : school.Subscription.NameEn,
                    RemainderOfSubscription = GetRemainderOfSubscription(school.SubscriptionStartDate),
                    SubscriptionYearlyAmount = school.SubscriptionPrice.ToString(),
                    SubscribeDate = school.SubscriptionStartDate.ToString()
                })
                .ToListAsync(cancellationToken);

            var paginatedList = new PaginatedList<SchoolsListDto>
            {
                Items = schools,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return ResultDto<PaginatedList<SchoolsListDto>>.Success(paginatedList);


        }
        public static string GetRemainderOfSubscription(DateTime startDate)
        {
            var remainingTime = DateTime.Now.Subtract(startDate);

            var months = (int)(remainingTime.TotalDays / 30);
            var days = (int)(remainingTime.TotalDays % 30);

            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar")
            {
                string monthText, dayText;

                switch (months)
                {
                    case 1:
                    case 2:
                        monthText = "شهر";
                        break;

                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        monthText = "أشهر";
                        break;
                    default:
                        monthText = "شهرًا";
                        break;
                }

                switch (days)
                {
                    case 1:
                        dayText = "يوم";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        dayText = "أيام";
                        break;
                    default:
                        dayText = "يومًا";
                        break;
                }

                return $"{months} {monthText} و {days} {dayText}";
            }
            else
            {
                return $"{months} Months and {days} Days";
            }
        }


    }
}
