using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Notifications.Dtos;

namespace GoldenAirport.Application.Notifications.Queries
{
    public class AdminNotificationsQuery : IRequest<ResponseDto<object>>
    {
        public class AdminNotificationsQueryHandler : IRequestHandler<AdminNotificationsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public AdminNotificationsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(AdminNotificationsQuery request, CancellationToken cancellationToken)
            {
                var tripsNotifications = await _dbContext.TripRegistrationsEditing
                    .Select(t => new AdminNotificationsDto
                    {
                        Name = _dbContext.AppUsers.Where(c => c.Id == t.CreatedById).Select(a => a.FirstName + a.LastName).FirstOrDefault(),                       
                        Date = t.CreationDate,
                        Content = "Trip modification request has been send",
                        FromCity = t.TripRegistration.Trip.City.NameAr,
                        ToCity = t.TripRegistration.Trip.ToCity.Select(d => d.Cities.NameAr).FirstOrDefault(),
                        PhoneNumber = t.PhoneNumber,
                    }).ToListAsync();

                var packagesNotifications = await _dbContext.PackageRegistrationsEditing
                    .Select(t => new AdminNotificationsDto
                    {
                        Name = _dbContext.AppUsers.Where(c => c.Id == t.CreatedById).Select(a => a.FirstName + a.LastName).FirstOrDefault(),                       
                        Date = t.CreationDate,
                        Content = "package modification request has been send",
                        FromCity = t.PackageRegistration.Package.City.NameAr,
                        ToCity = t.PackageRegistration.Package.ToCity.NameAr,
                        PhoneNumber = t.PhoneNumber,
                    }).ToListAsync();



                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Notifications",
                    Result = new
                    {
                        tripsNotifications,
                        packagesNotifications
                    }
                });
            }
        }
    }
}
