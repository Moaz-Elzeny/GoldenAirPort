using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.PackageRegistrations.Commands
{
    public class DeletePackageRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeletePackageRegistrationCommandHandler : IRequestHandler<DeletePackageRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeletePackageRegistrationCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(DeletePackageRegistrationCommand request, CancellationToken cancellationToken)
            {
                var package = await _dbContext.PackageRegistrations.Where(r => r.Id == request.Id && r.Package.IsRefundable == true).FirstOrDefaultAsync() ?? throw new NotFoundException("Can't Delete This Package");

                package.Deleted = true;
                package.ModificationDate = DateTime.Now;
                package.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

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
