using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Packagess.Commands.Delete
{
    public class DeletePackagePlanCommand : IRequest<ResponseDto<object>>
    {
        public int PackageId { get; set; }
        public int? PackagePlanId { get; set; }

        public class DeletePackagePlanHandler : IRequestHandler<DeletePackagePlanCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeletePackagePlanHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(DeletePackagePlanCommand request, CancellationToken cancellationToken)
            {
                var package = await _dbContext.Packages.FindAsync(request.PackageId) ?? throw new NotFoundException("Package not found.");

                if (request.PackagePlanId != null)
                {
                    var packagePlan = await _dbContext.PackagePlans.Where(pp => pp.PackageId == request.PackageId && pp.Id == request.PackagePlanId).FirstOrDefaultAsync();
                    if (packagePlan != null)
                    {
                        _dbContext.PackagePlans.Remove(packagePlan);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Deleted Successfully!",
                    Result = new
                    {
                        Package = package.Id
                    }
                });
            }
        }
    }
}
