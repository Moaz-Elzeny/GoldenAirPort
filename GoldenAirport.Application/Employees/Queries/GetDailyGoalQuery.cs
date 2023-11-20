using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetDailyGoalQuery : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public class GetDailyGoalQueryHandler : IRequestHandler<GetDailyGoalQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetDailyGoalQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetDailyGoalQuery request, CancellationToken cancellationToken)
            {
                //var query = await _dbContext.Employees.Where(e => e.Id == request.EmployeeId).FirstOrDefaultAsync();

                var dailyGoal = await _dbContext.DailyGoals.Where(e => e.Employee.AppUserId == request.EmployeeId)
                    .Select(x => new
                    {
                        //Name = x.Employee.AppUser.FirstName + " " + x.Employee.AppUser.LastName,
                        Target = x.Target,
                        Date = x.Date,
                        Goale = x.Goal
                    }).ToListAsync(cancellationToken);



                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "employee daily Goal",
                    Result =  dailyGoal
                    
                });
            }
        }
    }
}
