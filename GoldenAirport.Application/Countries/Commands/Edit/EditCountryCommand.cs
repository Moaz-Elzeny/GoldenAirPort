using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Countries.Commands.Edit
{
    public class EditCountryCommand : IRequest<ResultDto<object>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditCountyHandler : IRequestHandler<EditCountryCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditCountyHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(EditCountryCommand request, CancellationToken cancellationToken)
            {
                var county = await _dbContext.Countries.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");
                
                if(request.NameAr != null)
                {
                    county.NameAr = request.NameAr;
                }

                if(request.NameEn != null)
                {
                    county.NameEn = request.NameEn;
                }

                county.ModifiedById = request.CurrentUserId;
                county.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResultDto<object>.Success(county.Id ,"Country Updated Successfully!");
            }
        }
    }
}
