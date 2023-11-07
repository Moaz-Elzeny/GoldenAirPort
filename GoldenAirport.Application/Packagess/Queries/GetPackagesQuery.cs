using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Packagess.Dtos;
using GoldenAirport.Domain.Entities;
using System.Globalization;

namespace GoldenAirport.Application.Packagess.Queries
{
    public class GetPackagesQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;
        public int? FromCity { get; set; }
        public List<int>? ToCity { get; set; }
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
                .ThenInclude(c => c.City)
                .AsQueryable();

            if (request.FromCity != null)
            {
                query = query.Where(p => p.FromCityId == request.FromCity);
            }

            if (request.ToCity != null && request.ToCity.Any())
            {
                query = query.Where(p => p.ToCity.Any(c => request.ToCity.Contains(c.CityId)));
            }

            if (request.StartingOn != null)
            {
                query = query.Where(p => p.StartingDate == request.StartingOn);
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
                    Price = p.Price,
                    ChildPrice = p.ChildPrice,
                    //PriceLessThan12YearsOld = p.PriceLessThan12YearsOld,
                    CountryId = p.CountryId,
                    IsRefundable = p.IsRefundable,
                    //PaymentOptions = p.PaymentMethod,
                    FromCity = new FromCityDto
                    {

                    FromCityId = p.FromCityId,
                    CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? p.City.NameAr : p.City.NameEn,
                    },
                    ToCities = p.ToCity.Select(c => new GetPackegeCitiesDto
                    {
                        Id = c.CityId,
                        CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.City.NameAr : c.City.NameEn
                    }),
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
                Result = new
                {
                    result = paginatedList
                }
            });
        }
    }
}
