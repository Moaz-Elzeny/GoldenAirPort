using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Countries.Commands.Delete
{
    public class DeleteCountryCommand : IRequest<ResultDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteCountryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                var country = await _dbContext.Countries.FindAsync(request.Id) ?? throw new NotFoundException("Country not found.");
                
                country.Deleted = true;
                country.ModificationDate = DateTime.Now;
                country.ModifiedById = request.CurrentUserId; 

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<object>.Success(country.Id ,"Deleted has been successfully");
            }
        }
    }
}
