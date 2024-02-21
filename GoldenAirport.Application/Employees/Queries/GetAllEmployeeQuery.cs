using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Employees.Dtos;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetAllEmployeeQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; }
        public string? SearchKey { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetAllEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.Employees
                    .Where(a => !a.AppUser.Deleted)
                .AsQueryable();

                if (!string.IsNullOrEmpty(request.SearchKey))
                {
                    query = query.Where(e =>
                        e.AppUser.FirstName.Contains(request.SearchKey) ||
                        e.AppUser.LastName.Contains(request.SearchKey) ||
                        e.AppUser.PhoneNumber.Contains(request.SearchKey)
                    );
                }


                if (request.DateFrom != null)
                {
                    query = query.Where(t => t.LastLogin >= request.DateFrom);
                }

                if (request.DateTo != null)
                {
                    query = query.Where(t => t.LastLogin <= request.DateTo);
                }


                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                int skip = (request.PageNumber - 1) * 10;


                var employees = await query
                    .OrderByDescending(d => d.CreationDate)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(x => new GetAllEmployeeDto
                    {
                        Id = x.AppUserId,
                        Email = x.AppUser.Email,
                        UserName = x.AppUser.UserName,
                        FirstName = x.AppUser.FirstName,
                        LastName = x.AppUser.LastName,
                        PhoneNumber = x.AppUser.PhoneNumber,
                        UserType = x.AppUser.UserType,
                        ProfilePicture = x.AppUser.ProfilePicture.ToString(),
                        IsActive = x.Active,
                        AgentCode = x.AgentCode,
                        CountryCode = x.AppUser.Country.Code,
                        Balance = x.AppUser.Balances.Sum(s=>s.BalanceAmount),
                        DailyGoal = x.DailyGoals.Select(d => d.Goal).FirstOrDefault(),
                        ServiceFees = x.ServiceFees,                        
                        LastLogin = x.LastLogin,
                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetAllEmployeeDto>
                {
                    Items = employees,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All employee",
                    Result = new
                    {
                        Employees = paginatedList
                    }
                });
            }
        }
    }
}
