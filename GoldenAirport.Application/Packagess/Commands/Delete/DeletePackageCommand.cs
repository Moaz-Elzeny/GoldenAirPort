using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Packagess.Commands.Delete
{
    public class DeletePackageCommand : IRequest<ResultDto<string>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeletePackageHandler : IRequestHandler<DeletePackageCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeletePackageHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
            {
                var package = await _dbContext.Packages.FindAsync(request.Id) ?? throw new NotFoundException("Package not found.");

                package.Deleted = true;
                package.ModificationDate = DateTime.Now;
                package.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                var packagePlans = await _dbContext.PackagePlans.Where(pp => pp.PackageId == request.Id).ToListAsync();
                if (packagePlans.Count != 0)
                {
                    _dbContext.PackagePlans.RemoveRange(packagePlans);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }


                return ResultDto<string>.Success("Deletion has been successfully");
            }
        }
    }
}
