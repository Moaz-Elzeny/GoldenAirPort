using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Notifications.Dtos;
using System.Globalization;

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
                var user = _dbContext.AppUsers.AsQueryable();
                var tripsNotifications = await _dbContext.TripRegistrationsEditing
                    .Select(t => new AdminTripNotificationsDto
                    {
                        Id = t.Id,  
                        TripRegistrationId = t.TripRegistrationId,
                        TicketNumber = user.Where(c => c.Id == t.CreatedById).Select(a => a.Id).FirstOrDefault(),
                        ProfilePicture = user.Where(c => c.Id == t.CreatedById).Select(a => a.ProfilePicture).FirstOrDefault(),
                        Name = user.Where(c => c.Id == t.CreatedById).Select(a => a.FirstName +" " + a.LastName).FirstOrDefault(),                       
                        Date = t.CreationDate,
                        Content = "Trip modification request has been send",
                        FromCity = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.TripRegistration.Trip.City.NameAr : t.TripRegistration.Trip.City.NameEn,
                        ToCity = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.TripRegistration.Trip.ToCity.Select(d => d.Cities.NameAr).ToList() : t.TripRegistration.Trip.ToCity.Select(d => d.Cities.NameEn).ToList(),
                        PhoneNumber = t.PhoneNumber,
                    }).ToListAsync();

                var packagesNotifications = await _dbContext.PackageRegistrationsEditing
                    .Select(t => new AdminPackageNotificationsDto
                    {
                        Id = t.Id,
                        PackageRegistrationId = t.PackageRegistrationId,
                        TicketNumber = user.Where(c => c.Id == t.CreatedById).Select(a => a.Id).FirstOrDefault(),
                        ProfilePicture = user.Where(c => c.Id == t.CreatedById).Select(a => a.ProfilePicture).FirstOrDefault(),
                        Name = _dbContext.AppUsers.Where(c => c.Id == t.CreatedById).Select(a => a.FirstName +" "+ a.LastName).FirstOrDefault(),                       
                        Date = t.CreationDate,
                        Content = "package modification request has been send",
                        FromCity = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.PackageRegistration.Package.City.NameAr : t.PackageRegistration.Package.City.NameEn,
                        ToCity = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.PackageRegistration.Package.ToCity.NameAr : t.PackageRegistration.Package.ToCity.NameEn,
                        PhoneNumber = t.PhoneNumber,
                    }).ToListAsync();

                var totalCount = packagesNotifications.Count + tripsNotifications.Count;

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Notifications",
                    Result = new
                    {
                        tripsNotifications,
                        packagesNotifications,
                        totalCount

                    }
                });
            }
        }
    }
}
