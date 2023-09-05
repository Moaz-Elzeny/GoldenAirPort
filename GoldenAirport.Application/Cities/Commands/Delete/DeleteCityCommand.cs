using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Countries.Commands.Delete;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Cities.Commands.Delete
{
    public class DeleteCityCommand : IRequest<ResultDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteCityHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _dbContext.Cities.FindAsync(request.Id) ?? throw new NotFoundException("City not found.");

                city.Deleted = true;
                city.ModificationDate = DateTime.Now;
                city.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<object>.Success(city.Id ,"Deleted has been successfully");
            }
        }
    }
}
