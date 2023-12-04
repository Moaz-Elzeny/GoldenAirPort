using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.RegistrationsEditing.Commands.Edit
{
    public class PackageRegistrationEditingCommand : IRequest<ResponseDto<object>>
    {
        public int PackageRegistrationId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<AdultDto>? Adults { get; set; }
        public List<ChildDto>? Children { get; set; }
        public string? CurrentUserId { get; set; }

        public class PackageRegistrationEditingCommandHandler : IRequestHandler<PackageRegistrationEditingCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public PackageRegistrationEditingCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(PackageRegistrationEditingCommand request, CancellationToken cancellationToken)
            {

                var packageRegistration = new PackageRegistrationEditing
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    PackageRegistrationId = request.PackageRegistrationId,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now

                };

                _dbContext.PackageRegistrationsEditing.Add(packageRegistration);



                if (request.Adults.Count != null)
                {
                    _dbContext.AdultsEditing.RemoveRange();

                    foreach (var item in request.Adults)
                    {
                        packageRegistration.AdultsEditing.Add(new AdultEditing()
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
                    _dbContext.ChildrenEditing.RemoveRange();
                    foreach (var item in request.Children)
                    {
                        packageRegistration.ChildrenEditing.Add(new ChildEditing()
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

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "The request for amendment from the admin is being followed up",
                    Result = packageRegistration.Id
                });
            }
        }
    }
}
