using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Trips.Dtos;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetDailyGoalQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public class GetDailyGoalQueryHandler : IRequestHandler<GetDailyGoalQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetDailyGoalQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetDailyGoalQuery request, CancellationToken cancellationToken)
            {
                var query =  _dbContext.DailyGoals.AsQueryable();
                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 50;
                int skip = (request.PageNumber - 1) * 50;

                if (request.DateFrom != null)
                {
                    query = query.Where(t => t.Date <= request.DateFrom);
                }
                
                if (request.DateFrom != null)
                {
                    query = query.Where(t => t.Date >= request.DateTo);
                }

                var dailyGoal = await query.Where(e => e.Employee.AppUserId == request.EmployeeId)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(x => new
                    {
                        //Name = x.Employee.AppUser.FirstName + " " + x.Employee.AppUser.LastName,
                        Target = x.Target,
                        Date = x.Date,
                        Goale = x.Goal
                    }).ToListAsync(cancellationToken);

                var totalCount = dailyGoal.Count();

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var paginatedList = new PaginatedList<GetTripsDto>
                {
                    Items = dailyGoal,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };


                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "employee daily Goal",
                    Result = paginatedList

                });
            }
        }
    }
}
