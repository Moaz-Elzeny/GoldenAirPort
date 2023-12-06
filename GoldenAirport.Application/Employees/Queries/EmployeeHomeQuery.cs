using GoldenAirport.Application.Common.Models;

namespace GoldenAirport.Application.Employees.Queries
{
    public class EmployeeHomeQuery : IRequest<ResponseDto<object>>
    {
        public string UserId { get; set; }
        public class EmployeeHomeQueryHandler : IRequestHandler<EmployeeHomeQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EmployeeHomeQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EmployeeHomeQuery request, CancellationToken cancellationToken)
            {

                var home = await _dbContext.Employees.Where(a => a.AppUserId == request.UserId)
                    .Select(d => new
                    {
                        ProfilePicture = d.AppUser.ProfilePicture,
                        Name = $"{d.AppUser.FirstName} {d.AppUser.LastName}",
                        AgentCode = d.AgentCode,
                        lastLogin = d.LastLogin,
                        Balance = d.AppUser.Balances.Sum(a => a.BalanceAmount),
                        DailyGoal = d.DailyGoals.OrderByDescending(d => d.Date).
                        Select(g => new
                        {
                            DailyGoal =  g.Goal,
                            Target = g.Employee.Target,
                        }).FirstOrDefault()

                    }).ToListAsync();


                return ResponseDto<object>.Success(new Helpers.DTOs.ResultDto()
                {
                    Message = "Home",
                    Result = new
                    {
                        home
                    }
                });
            }
        }
    }
}
