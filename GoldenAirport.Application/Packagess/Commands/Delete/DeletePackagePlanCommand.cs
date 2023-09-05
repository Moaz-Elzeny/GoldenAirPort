using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Packagess.Commands.Delete
{
    public class DeletePackagePlanCommand : IRequest<ResultDto<object>>
    {
        public int PackageId { get; set; }
        public int? PackagePlanId { get; set; }

        public class DeletePackagePlanHandler : IRequestHandler<DeletePackagePlanCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeletePackagePlanHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(DeletePackagePlanCommand request, CancellationToken cancellationToken)
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

                return ResultDto<object>.Success(package.Id, "Deletion has been successfully");
            }
        }
    }
}
