using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Trips.Dtos;
using System.Globalization;

namespace GoldenAirport.Application.Trips.Queries
{
    public class GetTripsQuery : IRequest<ResultDto<PaginatedList<GetTripsDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int? FromCity { get; set; }
        public List<int>? ToCity { get; set; }
        public DateTime? StartingOn { get; set; }
        public int? Guests { get; set; }

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
                    .Include(r => r.TripRegistrations)
                    .ThenInclude(a => a.Adults)
                .AsQueryable();

                if(request.FromCity != null)
                {
                    query = query.Where(t => t.FromCityId == request.FromCity);
                }

                if (request.ToCity != null && request.ToCity.Any())
                {
                    query = query.Where(t => t.ToCity.Any(c => request.ToCity.Contains(c.CityId)));
                }

                if (request.StartingOn != null)
                {
                    query = query.Where(t => t.StartingDate == request.StartingOn);
                }

                if (request.Guests != null)
                {
                    var guests = _dbContext.Trips.Where(g => g.Guests >= request.Guests).Select(t => t.Guests).ToList();

                    //var r = guests * _dbContext.TripRegistrations.Where(r => r.Id).Select(r => r.Adults).ToList();
                    query = query.Where(r => guests.Contains(r.Guests));
                }

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
