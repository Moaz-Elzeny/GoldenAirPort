using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Notifications.Dtos;

namespace GoldenAirport.Application.Notifications.Queries
{
    public class EmployeeNotificationsQuery : IRequest<ResponseDto<object>>
    {
        public class EmployeeNotificationsQueryHandler : IRequestHandler<EmployeeNotificationsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EmployeeNotificationsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EmployeeNotificationsQuery request, CancellationToken cancellationToken)
            {
                var Notifications = await _dbContext.Notifications
                    .Select(n => new EmployeeNotificationsDto
                    {
                        EmployeeId = n.AppUserId,
                        Date = n.Date,
                        Message = n.Title,
                        Imgage = n.Content,

                    }).ToListAsync();


                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Notifications",
                    Result = Notifications                 
                });
            }
        }
    }
}
