using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;
using GoldenAirport.Application.RegistrationsEditing.DTOs;
using GoldenAirport.Application.Trips.Dtos;
using System.Globalization;

namespace GoldenAirport.Application.RegistrationsEditing.Queries
{
    public class TripRegistrationEditingByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }

        public class TripRegistrationEditingByIdQueryHandler : IRequestHandler<TripRegistrationEditingByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public TripRegistrationEditingByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(TripRegistrationEditingByIdQuery request, CancellationToken cancellationToken)
            {

                var query = _dbContext.TripRegistrationsEditing
                    .Include(r => r.AdultsEditing)
                    .Include(c => c.ChildrenEditing)
                    .AsSplitQuery()
                    .AsQueryable();

                var tripRegistrations = await query
                    .Where(t => t.Id == request.Id)
                    .Select(t => new TripRegistrationEditingByIdDto
                    {
                        Id = t.Id,
                        TripRegistrationId = t.TripRegistrationId,
                        AdultCost = t.TripRegistration.AdultCost,
                        ChildCost = t.TripRegistration.ChildCost,
                        TotalAmount = t.TripRegistration.TotalAmount,
                        StartingDate = t.TripRegistration.Trip.StartingDate.Date,
                        EndingDate = t.TripRegistration.Trip.EndingDate.Date,
                        TripHours = t.TripRegistration.Trip.TripHours.ToString(@"hh\:mm"),
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,
                        FromCity = new GetFromCityDto
                        {
                            Id = t.TripRegistration.Trip.FromCityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.TripRegistration.Trip.City.NameAr : t.TripRegistration.Trip.City.NameEn,
                        },
                        ToCities = t.TripRegistration.Trip.ToCity.Select(c => new GetCitiesDto
                        {
                            Id = c.CityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.Cities.NameAr : c.Cities.NameEn
                        }),
                        Adults = t.AdultsEditing.Select(a => new AdultTripRegistrationDto
                        {

                            Title = a.Title,
                            TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>(a.Title),
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            AdultPassportNo = a.PassportNo,
                            DateOfBirth = a.DateOfBirth,
                        }).ToList(),
                        Children = t.ChildrenEditing.Select(c => new ChildrenTripRegistrationDto
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            AdultPassportNo = c.PassportNo,
                            DateOfBirth = c.DateOfBirth,
                        }).ToList(),
                        WhyVisit = t.TripRegistration.Trip.WhyVisits.Select(w => new TripDescription
                        {
                            Id = w.Id,
                            Description = w.Description,

                        }),

                        WhatIsIncluded = t.TripRegistration.Trip.WhatAreIncluded.Select(w => new TripDescription
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),
                        Accessibility = t.TripRegistration.Trip.Accessibilities.Select(w => new TripDescription
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),
                        Restrictions = t.TripRegistration.Trip.Restrictions.Select(w => new TripDescription
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),

                    }).ToListAsync(cancellationToken);

                if (tripRegistrations.Count != 0)
                {
                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Trip Registration",
                        Result = tripRegistrations,
                    });
                }
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Message = "Something Error!",
                    Code = 101
                });
            }
        }
    }
}
