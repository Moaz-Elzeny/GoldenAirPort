using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.PackageRegistrations.Commands.Edit
{
    public class ApprovePackageRegistrationEditingCommand : IRequest<ResponseDto<object>>
    {
        public int PackageRegistrationId { get; set; }
        public bool Approve { get; set; }
        public string? CurrentUserId { get; set; }

        public class ApprovePackageRegistrationEditingCommandHandler : IRequestHandler<ApprovePackageRegistrationEditingCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public ApprovePackageRegistrationEditingCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(ApprovePackageRegistrationEditingCommand request, CancellationToken cancellationToken)
            {
                var packageRegistrationEditing = await _dbContext.PackageRegistrationsEditing.Include(a => a.AdultsEditing).Include(c => c.ChildrenEditing)
                    .Where(p => p.PackageRegistrationId == request.PackageRegistrationId).FirstOrDefaultAsync() ?? throw new Exception("Package Registration not found");

                var PackageRegistration = await _dbContext.PackageRegistrations.Include(a => a.Adults).Include(c => c.Children)
                    .Where(p => p.Id == request.PackageRegistrationId).FirstOrDefaultAsync() ?? throw new Exception("Package Registration not found");

                if (request.Approve)
                {
                    PackageRegistration.AdultCost = PackageRegistration.AdultCost;
                    PackageRegistration.ChildCost = PackageRegistration.ChildCost;
                    PackageRegistration.AdminFees = PackageRegistration.AdminFees;
                    PackageRegistration.EmployeeFees = PackageRegistration.EmployeeFees;
                    PackageRegistration.Taxes = PackageRegistration.Taxes;
                    PackageRegistration.Email = packageRegistrationEditing.Email;
                    PackageRegistration.PhoneNumber = packageRegistrationEditing.PhoneNumber;
                    PackageRegistration.PackageId = PackageRegistration.PackageId;
                    PackageRegistration.CreatedById = request.CurrentUserId;
                    PackageRegistration.CreationDate = DateTime.Now;

                    if (packageRegistrationEditing.AdultsEditing.Count != 0)
                    {


                        foreach (var item in packageRegistrationEditing.AdultsEditing)
                        {
                            PackageRegistration.Adults.Add(new Adult()
                            {
                                Title = item.Title,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = DateTime.Now,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }


                    //child
                    if (packageRegistrationEditing.ChildrenEditing.Count != 0)
                    {

                        foreach (var item in packageRegistrationEditing.ChildrenEditing)
                        {
                            PackageRegistration.Children.Add(new Child()
                            {
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = DateTime.Now,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }

                     _dbContext.PackageRegistrationsEditing.RemoveRange(packageRegistrationEditing);

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Updated Successfully!",
                        Result = new
                        {
                            result = PackageRegistration.Id
                        }
                    });
                }

                _dbContext.PackageRegistrationsEditing.RemoveRange(packageRegistrationEditing);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Unacceptable!",
                    Result = new
                    {
                        result = PackageRegistration.Id
                    }
                });
            }
        }
    }
}