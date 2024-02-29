using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Application.Trips.Dtos;
using GoldenAirport.Domain.Enums;
using System.Globalization;

namespace GoldenAirport.Application.TripRegistrations.Queries
{
    public class GetTripRegistrationQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; }
        public string? UserId { get; set; }
        public string? CurrentUserId { get; set; }


        public class GetTripRegistrationQueryHandler : IRequestHandler<GetTripRegistrationQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripRegistrationQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTripRegistrationQuery request, CancellationToken cancellationToken)
            {

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.TripRegistrations
                    .Include(r => r.Adults)
                    .Include(c => c.Children)
                    .AsQueryable();

                if (request.UserId == null && request.CurrentUserId != null)
                {
                    query = query.Where(tr => tr.CreatedById == request.CurrentUserId);
                }
                
                if (request.UserId != null && request.CurrentUserId != null)
                {
                    query = query.Where(tr => tr.CreatedById == request.UserId);
                }

                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var TitleValues = Enum.GetValues<Title>();
                var TripRegistrations = await query
                    .OrderByDescending(d => d.CreationDate)
                    .Select(t => new GetTripRegistrationDto
                    {
                        Id = t.Id,
                        TripId = t.TripId,
                        StartingDate = t.Trip.StartingDate.Date,
                        EndingDate = t.Trip.EndingDate,                                              
                        TripHours = t.Trip.TripHours.ToString(@"hh\:mm"),
                        IsRefundable = t.Trip.IsRefundable,
                        RegistrationDeleteing = t.RegistrationDeleteing,
                        TotalAmount = t.TotalAmount,
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


                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetTripRegistrationDto>
                {
                    Items = TripRegistrations,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All TripRegistration ",
                    Result =  paginatedList
                    
                });
            }
        }
    }
}
