using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Notifications.Dtos;

namespace GoldenAirport.Application.Notifications.Queries
{
    public class EmployeeNotificationsQuery : IRequest<ResponseDto<object>>
    {
        public string? CurrentUserId { get; set; }

        public class EmployeeNotificationsQueryHandler : IRequestHandler<EmployeeNotificationsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EmployeeNotificationsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EmployeeNotificationsQuery request, CancellationToken cancellationToken)
            {
                var Notifications = await _dbContext.Notifications.Where(e => e.AppUserId == request.CurrentUserId)
                    .Select(n => new EmployeeNotificationsDto
                    {
                        EmployeeId = n.AppUserId,
                        //ProfilePicture = n.AppUser.ProfilePicture,
                        Date = n.Date,
                        Message = n.Title,
                        Image = n.Content,

                    }).ToListAsync();
                var totalCount = Notifications.Count;

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Notifications",
                    Result = new
                    {
                        Notifications,
                        totalCount
                    }
                });
            }
        }
    }
}
