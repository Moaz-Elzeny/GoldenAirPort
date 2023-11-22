using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Application.Trips.Dtos;
using GoldenAirport.Domain.Enums;
using System.Globalization;

namespace GoldenAirport.Application.TripRegistrations.Queries
{
    public class GetTripRegistrationByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }


        public class GetTripRegistrationByIdQueryHandler : IRequestHandler<GetTripRegistrationByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripRegistrationByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTripRegistrationByIdQuery request, CancellationToken cancellationToken)
            {

                var query = _dbContext.TripRegistrations
                    .Include(r => r.Adults)
                    .AsQueryable();

                var TitleValues = Enum.GetValues<Title>();

                var TripRegistrations = await query
                    .Where(t => t.Id == request.Id)
                    .Select(t => new GetTripRegistrationByIdDto
                    {
                        Id = t.Id,
                        TripId = t.TripId,
                        AdultCost = t.AdultCost,
                        ChildCost = t.ChildCost,
                        //AdminFees = t.AdminFees ?? 0,
                        //EmployeeFees = t.EmployeeFees,
                        //Taxes = t.Taxes,
                        TotalAmount = t.TotalAmount,
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,
                        StartingDate = t.Trip.StartingDate.Date,
                        EndingDate = t.Trip.EndingDate,
                        TripHours = t.Trip.TripHours.ToString(@"hh\:mm"),
                        FromCities = new GetFromCityDto
                        {
                            Id = t.Trip.FromCityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.Trip.City.NameAr : t.Trip.City.NameEn,
                        },
                        ToCities = t.Trip.ToCity.Select(c => new GetCitiesDto
                        {
                            Id = c.CityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.Cities.NameAr : c.Cities.NameEn
                        }),
                        Adults = t.Adults.Select(a => new AdultTripRegistrationDto
                        {

                        Title =  a.Title,
                        TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>( a.Title),
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        AdultPassportNo = a.PassportNo,
                        DateOfBirth = a.DateOfBirth,
                        }).ToList(),
                        Children = t.Children.Select(c => new ChildrenTripRegistrationDto
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            AdultPassportNo = c.PassportNo,
                            DateOfBirth = c.DateOfBirth,
                        }).ToList(),
                        WhyVisit = t.Trip.WhyVisits.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description,

                        }),

                        WhatIsIncluded = t.Trip.WhatAreIncluded.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),
                        Accessibility = t.Trip.Accessibilities.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),
                        Restrictions = t.Trip.Restrictions.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),

                    }).ToListAsync(cancellationToken);

                if (TripRegistrations.Count != 0)
                {
                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Trip Registration!",
                        Result = TripRegistrations
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
