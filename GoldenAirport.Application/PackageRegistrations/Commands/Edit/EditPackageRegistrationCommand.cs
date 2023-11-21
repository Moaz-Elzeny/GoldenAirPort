using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.PackageRegistrations.Commands.Edit
{
    public class EditPackageRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<AdultDto>? Adults { get; set; }
        public List<ChildDto>? Children { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditPackageRegistrationCommandHandler : IRequestHandler<EditPackageRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditPackageRegistrationCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditPackageRegistrationCommand request, CancellationToken cancellationToken)
            {

                 var packageRegistration = await _dbContext.PackageRegistrations
                    .Include(a => a.Adults)
                    .Include(a => a.Children)
                    .FirstOrDefaultAsync(t => t.Id == request.Id) ?? throw new NotFoundException("Package Registration not found.");

                //if (request.CurrentUserId == user.Select(u => u.Id).FirstOrDefault())
                //{

                if (!request.Email.IsNullOrEmpty())
                {
                    packageRegistration.Email = request.Email ;

                }
                if (!request.PhoneNumber.IsNullOrEmpty())
                {
                    packageRegistration.PhoneNumber = request.PhoneNumber;

                }
                    packageRegistration.ModifiedById = request.CurrentUserId;
                    packageRegistration.ModificationDate = DateTime.Now;

                    if (request.Adults.Count != null)
                    {
                        //var adult = await _dbContext.Adults.Where(a => a.PackageRegistrationId == request.Id).ToListAsync();
                        //if (adult == null)
                        //{

                        //}

                        foreach (var item in request.Adults)
                        {
                            packageRegistration.Adults.Add(new Adult()
                            {
                                Title = item.Title.Value,
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
                    if (request.Children.Count != 0)
                    {

                        foreach (var item in request.Children)
                        {
                            packageRegistration.Children.Add(new Child()
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
                //}

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully!",
                    Result = new
                    {
                        result = packageRegistration.Id
                    }
                });
            }
        }
    }
}
