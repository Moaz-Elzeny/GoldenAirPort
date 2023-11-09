using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Packagess.Commands.Delete
{
    public class DeletePackageCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeletePackageHandler : IRequestHandler<DeletePackageCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeletePackageHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
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
