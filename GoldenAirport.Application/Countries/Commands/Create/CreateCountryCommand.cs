using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Countries.Commands.Create
{
    public class CreateCountryCommand : IRequest<ResultDto<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateCountryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                var country = new Country
                {
                    NameAr = request.NameAr,
                    NameEn = request.NameEn,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,

                };

                _dbContext.Countries.Add(country);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Country Created Successfully!");
            }
        }
    }
}
