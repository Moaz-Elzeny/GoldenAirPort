using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Countries.Commands.Create
{
    public class CreateCountryCommand : IRequest<ResponseDto<object>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public byte Code { get; set; }
        public IFormFile Icon { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IHostingEnvironment _environment;

            public CreateCountryHandler(IApplicationDbContext dbContext, IHostingEnvironment environment)
            {
                _dbContext = dbContext;
                _environment = environment;
            }

            public async Task<ResponseDto<object>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                var country = new Country
                {
                    NameAr = request.NameAr,
                    NameEn = request.NameEn,
                    Code = request.Code,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,

                };

                if (request.Icon != null)
                {
                    country.Icon = await FileHelper.SaveImageAsync(request.Icon, _environment);
                }

                _dbContext.Countries.Add(country);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully!",
                    Result = new
                    {
                        country = country.Id
                    }
                });
            }
        }
    }
}
