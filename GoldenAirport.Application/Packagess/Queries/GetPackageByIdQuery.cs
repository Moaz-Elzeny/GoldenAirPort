using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Packagess.Dtos;
using System.Globalization;

namespace GoldenAirport.Application.Packagess.Queries
{
    public class GetPackageByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }       
    }

    public class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, ResponseDto<object>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetPackageByIdQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseDto<object>> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var package = await _dbContext.Packages
                .Where(t => t.Id == request.Id)
                .Select(p => new GetPackageByIdDto
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
                    ToCity = new GetPackegeCitiesDto
                    {
                        Id = p.ToCityId,
                        CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? p.ToCity.NameAr : p.ToCity.NameEn
                    },
                    PackagePlan = p.PackagePlans.Select(pp => new PackagePlanDto
                    {
                        Id = pp.Id,
                        Description = pp.Description
                    })
                }).FirstOrDefaultAsync(cancellationToken);

            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "package",
                Result = package
            });
        }
    }
}
