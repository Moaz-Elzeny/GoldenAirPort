using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Countries.Dtos;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Trips.Dtos;
using System.Globalization;
using System.Linq;

namespace GoldenAirport.Application.Trips.Queries
{
    public class GetTripsQuery : IRequest<ResultDto<PaginatedList<GetTripsDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public string? SearchKey { get; set; }

        public class GetTripsQueryHandler : IRequestHandler<GetTripsQuery, ResultDto<PaginatedList<GetTripsDto>>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<PaginatedList<GetTripsDto>>> Handle(GetTripsQuery request, CancellationToken cancellationToken)
            {

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.Trips
                .AsQueryable();

              

                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var Trips = await query
                    .Select(t => new GetTripsDto
                    {
                        Id = t.Id,
                        StartingDate = t.StartingDate.Date,
                        EndingDate = t.EndingDate,
                        Guests = t.Guests,
                        Price = t.Price,
                        TripHours = t.TripHours.ToString(),
                        FromCityId = t.FromCityId,
                        FromCityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.City.NameAr : t.City.NameEn,
                        ToCities = t.ToCity.Select(c => new GetCitiesDto 
                        { 
                            Id = c.CityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.Cities.NameAr : c.Cities.NameEn 
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

                return ResultDto<PaginatedList<GetTripsDto>>.Success(paginatedList);
            }
        }
    }
}
