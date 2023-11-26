using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Trips.Dtos;
using System.Globalization;

namespace GoldenAirport.Application.Trips.Queries
{
    public class GetTripByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
       

        public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
            {

                var query = _dbContext.Trips
                    .Include(r => r.TripRegistrations)
                    .ThenInclude(a => a.Adults)
                .AsQueryable();

                var Trips = await query
                    .Select(t => new GetTripsDto
                    {
                        Id = t.Id,
                        StartingDate = t.StartingDate.Date,
                        EndingDate = t.EndingDate,
                        //Guests = t.Guests,
                        //RemainingGuests = t.RemainingGuests,
                        AdultPrice = t.Price,
                        ChildPrice = t.ChildPrice,
                        TripHours = t.TripHours.ToString(@"hh\:mm"),
                        IsRefundable = t.IsRefundable,
                        FromCities = new GetFromCityDto
                        {
                            Id = t.FromCityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.City.NameAr : t.City.NameEn,
                        },
                        ToCities = t.ToCity.Select(c => new GetCitiesDto
                        {
                            Id = c.CityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.Cities.NameAr : c.Cities.NameEn
                        }),
                        WhyVisit = t.WhyVisits.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description,

                        }),

                        WhatIsIncluded = t.WhatAreIncluded.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),
                        Accessibility = t.Accessibilities.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),
                        Restrictions = t.Restrictions.Select(w => new
                        {
                            Id = w.Id,
                            Description = w.Description
                        }),
                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetTripsDto>
                {
                    Items = Trips,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All Trips",
                    Result = new
                    {
                        paginatedList,
                        allTrips
                    }
                });
            }
        }
    }
}
