using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Packagess.Dtos;
using System.Globalization;

namespace GoldenAirport.Application.Packagess.Queries
{
    public class GetPackagesQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;
        public int? FromCity { get; set; }
        public int? ToCity { get; set; }
        public DateTime? StartingOn { get; set; }
        public int? Guests { get; set; }
    }

    public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, ResponseDto<object>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetPackagesQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseDto<object>> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
            var pageSize = 10;

            var query = _dbContext.Packages
                .Include(p => p.ToCity)                
                .AsQueryable();

            var allPackages = await query.CountAsync(cancellationToken);

            if (request.FromCity != null)
            {
                query = query.Where(p => p.FromCityId == request.FromCity);
            }

            if (request.ToCity != null )
            {
                query = query.Where(p => p.ToCityId == request.ToCity);
            }

            if (request.StartingOn != null)
            {
                query = query.Where(p => p.StartingDate == request.StartingOn);
            }


            if (request.Guests != null)
            {
                var guests = _dbContext.Packages.Where(g => g.RemainingGuests >= request.Guests).Select(t => t.Guests).ToList();
                query = query.Where(r => guests.Contains(r.Guests));
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var packages = await query
                .Select(p => new GetPackagesDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    StartingDate = p.StartingDate.Date,
                    EndingDate = p.EndingDate,
                    AdultPrice = p.Price,
                    ChildPrice = p.ChildPrice,   
                    AboutExploreTour = p.AboutExploreTour,
                    IsRefundable = p.IsRefundable,
                    FromCity = new FromCityDto
                    {

                    Id = p.FromCityId,
                    CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? p.City.NameAr : p.City.NameEn,
                    },
                    ToCity =  new GetPackegeCitiesDto
                    {
                        Id = p.ToCityId,
                        CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? p.ToCity.NameAr : p.ToCity.NameEn
                    },
                    PackagePlan = p.PackagePlans.Select(pp => new
                    {
                        Id = pp.Id,
                        Description = pp.Description
                    })
                }).ToListAsync(cancellationToken);

            var paginatedList = new PaginatedList<GetPackagesDto>
            {
                Items = packages,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "All package",
                Result = new { paginatedList , allPackages }
            });
        }
    }
}
