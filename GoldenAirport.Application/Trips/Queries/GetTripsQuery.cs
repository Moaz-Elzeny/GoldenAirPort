using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Trips.Dtos;
using System.Globalization;

namespace GoldenAirport.Application.Trips.Queries
{
    public class GetTripsQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;
        public int? FromCity { get; set; }
        public List<int>? ToCity { get; set; }
        public DateTime? StartingOn { get; set; }
        public int? Guests { get; set; }

        public class GetTripsQueryHandler : IRequestHandler<GetTripsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTripsQuery request, CancellationToken cancellationToken)
            {

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.Trips
                    .Include(r => r.TripRegistrations)
                    .ThenInclude(a => a.Adults)
                .AsQueryable();

                var ra = _dbContext.TripRegistrations.Select(r => r.Id);
                var ad = _dbContext.Adults.Where(a => ra.Contains(a.TripRegistrationId)).Select(a => a.Id);

                if (request.FromCity != null)
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
                    var x = guests.Count() - ad.Count();
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
                        //Guests = t.Guests,
                        //RemainingGuests = t.RemainingGuests,
                        AdultPrice = t.Price,
                        ChildPrice = t.ChildPrice,
                        TripHours = t.TripHours.ToString(@"hh\:mm"),
                        IsRefundable = t.IsRefundable,
                        Cities = t.ToCity.Select(c => new GetCitiesDto
                        {
                            City = new GetFromCityDto
                            {
                                Id = t.FromCityId,
                                CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.City.NameAr : t.City.NameEn,
                            } ,
                            Id = c.CityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.Cities.NameAr : c.Cities.NameEn
                        }),
                        //PaymentOptions = t.PaymentOptionTrips.Select(p => new
                        //{
                        //    Id = p.PaymentOptionId,
                        //    Type = p.PaymentOptions.NameAr
                        //}),
                        //WhyVisit = t.WhyVisits.Select(w => new
                        //{
                        //    Id = w.Id,
                        //    Description = w.Description,

                        //}),

                        //WhatIsIncluded = t.WhatAreIncluded.Select(w => new
                        //{
                        //    Id = w.Id,
                        //    Description = w.Description
                        //}),
                        //Accessibility = t.Accessibilities.Select(w => new
                        //{
                        //    Id = w.Id,
                        //    Description = w.Description
                        //}),
                        //Restrictions = t.Restrictions.Select(w => new
                        //{
                        //    Id = w.Id,
                        //    Description = w.Description
                        //}),

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
                    Result = paginatedList
                });
            }
        }
    }
}
