using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.PackageRegistrations.Commands.Delete
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
                var user = _dbContext.AppUsers.Where(a => a.Id == request.CurrentUserId).FirstOrDefault();

                var package = await _dbContext.PackageRegistrations.Where(r => r.Id == request.Id && r.Package.IsRefundable == true).FirstOrDefaultAsync() ?? throw new NotFoundException("Can't Delete This Package");

                if (user.UserType == UserType.SuperAdmin)
                {
                    package.Deleted = true;
                    package.ModificationDate = DateTime.Now;
                    package.ModifiedById = request.CurrentUserId;
                }

                else
                {
                    var PackageRegistrationDeleting = new PackageRegistrationDeleting
                    {
                        PackageRegistrationId = request.Id,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    };
                    await _dbContext.PackageRegistrationsDeleting.AddAsync(PackageRegistrationDeleting);
                    package.RegistrationDeleteing = true;
                }

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
