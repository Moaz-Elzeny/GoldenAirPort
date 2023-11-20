using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetStatementQuery : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public class GetTargetQueyHandler : IRequestHandler<GetTargetQuey, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTargetQueyHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTargetQuey request, CancellationToken cancellationToken)
            {
                //var query = await _dbContext.Employees.Where(e => e.Id == request.EmployeeId).FirstOrDefaultAsync();

                var dailyGoal = await _dbContext.DailyGoals.Where(e => e.Employee.AppUserId == request.EmployeeId)
                    .Select(x => new
                    {

                        Target = x.Target,

                    }).ToListAsync(cancellationToken);



                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "employee daily Goal",
                    Result = dailyGoal
                });
            }
        }
    }
}
