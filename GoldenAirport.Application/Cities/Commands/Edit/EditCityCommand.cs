using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Cities.Commands.Edit
{
    public class EditCityCommand : IRequest<ResultDto<object>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int? CountryId { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditCityHandler : IRequestHandler<EditCityCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditCityHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(EditCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _dbContext.Cities.FindAsync(request.Id) ?? throw new NotFoundException("City not found.");

                if (request.NameAr != null)
                {
                    city.NameAr = request.NameAr;
                }

                if (request.NameEn != null)
                {
                    city.NameEn = request.NameEn;
                }

                city.CountryId = request.CountryId ?? city.CountryId;

                city.ModifiedById = request.CurrentUserId;
                city.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResultDto<object>.Success(city.Id, "City Updated Successfully!");
            }
        }
    }
}
