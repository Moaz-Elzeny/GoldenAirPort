using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Cities.Commands.Delete
{
    public class DeleteCityCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteCityHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _dbContext.Cities.FindAsync(request.Id) ?? throw new NotFoundException("City not found.");

                city.Deleted = true;
                city.ModificationDate = DateTime.Now;
                city.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Deleted Successfully",
                    Result = new
                    {
                        CityId = city.Id
                    }
                });
            }
        }
    }
}
