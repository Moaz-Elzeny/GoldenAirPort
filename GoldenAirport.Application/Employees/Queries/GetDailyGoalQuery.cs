using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetDailyGoalQuery : IRequest<ResponseDto<object>>
    {
        public class GetDailyGoalQueryHandler : IRequestHandler<GetDailyGoalQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetDailyGoalQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetDailyGoalQuery request, CancellationToken cancellationToken)
            {

                var PaymentOption = await _dbContext.DailyGoals
                    .Select(x => new
                    {
                        Target = x.Target,
                        Date = x.Date,
                        Goale = x.Goal
                    }).ToListAsync(cancellationToken);



                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All employee",
                    Result = new
                    {
                        PaymentOption
                    }
                });
            }
        }
    }
}
