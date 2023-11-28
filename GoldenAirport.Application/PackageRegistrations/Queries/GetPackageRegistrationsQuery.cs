using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.PackageRegistrations.Dtos;
using GoldenAirport.Application.Packagess.Dtos;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;
using System.Globalization;

namespace GoldenAirport.Application.PackageRegistrations.Queries
{
    public class GetPackageRegistrationsQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; }
        public string? CurrentUserId { get; set; }


        public class GetPackageRegistrationsQueryHandler : IRequestHandler<GetPackageRegistrationsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetPackageRegistrationsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetPackageRegistrationsQuery request, CancellationToken cancellationToken)
            {

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.PackageRegistrations
                    .Include(r => r.Adults)
                    .Include(c => c.Children)
                    .Where(tp => tp.CreatedById == request.CurrentUserId)
                    .AsQueryable();

                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var TitleValues = Enum.GetValues<Title>();
                var PackageRegistrations = await query
                    .Select(t => new GetPackageRegistrationDto
                    {
                        Id = t.Id,
                        PackageId = t.PackageId,
                        PackageName = t.Package.Name,
                        StartingDate = t.Package.StartingDate.Date,
                        EndingDate = t.Package.EndingDate.Date,
                        Day = t.Package.EndingDate.DayOfYear - t.Package.StartingDate.DayOfYear,
                        Night = (t.Package.EndingDate.DayOfYear - t.Package.StartingDate.DayOfYear) -1,
                        AdultPrice = t.Package.Price,
                        ChildPrice = t.Package.ChildPrice,
                        IsRefundable = t.Package.IsRefundable,
                        ServiceFees = t.AdminFees + t.EmployeeFees,
                        FromCity = new FromCityDto
                        {
                            Id = t.Package.FromCityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.Package.City.NameAr : t.Package.City.NameEn,
                        },
                        ToCity = new GetPackegeCitiesDto
                        {
                         Id =  t.Package.ToCityId,
                        CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.Package.ToCity.NameAr : t.Package.ToCity.NameEn ,
                        }
                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetTripRegistrationDto>
                {
                    Items = PackageRegistrations,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All Package Registration ",
                    Result = paginatedList

                });
            }
        }
    }
}
