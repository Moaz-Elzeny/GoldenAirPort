using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Cities.Commands.Create
{
    public class CreateCityCommand : IRequest<ResponseDto<object>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CountryId { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateCityHandler : IRequestHandler<CreateCityCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateCityHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var city = new City
                {
                    NameAr = request.NameAr,
                    NameEn = request.NameEn,
                    CountryId = request.CountryId,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,

                };

                _dbContext.Cities.Add(city);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully ✔️",
                    Result = new
                    {
                        CityId = city.Id,
                    }
                });
            }
        }
    }
}
