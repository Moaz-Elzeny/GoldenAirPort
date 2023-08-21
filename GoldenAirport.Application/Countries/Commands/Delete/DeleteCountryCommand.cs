using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Countries.Commands.Delete
{
    public class DeleteCountryCommand : IRequest<ResultDto<string>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteCountryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                var country = await _dbContext.Countries.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");
                
                country.Deleted = true;
                country.ModificationDate = DateTime.Now;
                country.ModifiedById = request.CurrentUserId; 

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Deleted has been successfully");
            }
        }
    }
}
