﻿using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.RegistrationsEditing.Commands.Edit;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
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
            private readonly IMediator _mediator;

            public EditPackageRegistrationCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(EditPackageRegistrationCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.AppUsers.Where(a => a.Id == request.CurrentUserId).FirstOrDefault();

                var packageRegistration = await _dbContext.PackageRegistrations
                    .Include(a => a.Adults)
                    .Include(a => a.Children)
                    .FirstOrDefaultAsync(t => t.Id == request.Id) ?? throw new NotFoundException("Package Registration not found.");

                if (user.UserType == UserType.SuperAdmin)
                {

                    if (!request.Email.IsNullOrEmpty())
                    {
                        packageRegistration.Email = request.Email;

                    }
                    if (!request.PhoneNumber.IsNullOrEmpty())
                    {
                        packageRegistration.PhoneNumber = request.PhoneNumber;

                    }
                    packageRegistration.ModifiedById = request.CurrentUserId;
                    packageRegistration.ModificationDate = DateTime.Now;

                    if (request.Adults.Count != null)
                    {
                        _dbContext.Adults.RemoveRange(packageRegistration.Adults);
                        foreach (var item in request.Adults)
                        {
                            packageRegistration.Adults.Add(new Adult()
                            {
                                Title = item.Title.Value,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = item.DateOfBirth.Value,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }

                    //child
                    if (request.Children.Count != 0)
                    {
                        _dbContext.Children.RemoveRange(packageRegistration.Children);
                        foreach (var item in request.Children)
                        {
                            packageRegistration.Children.Add(new Child()
                            {
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                PassportNo = item.PassportNo,
                                DateOfBirth = item.DateOfBirth.Value,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now,
                            });
                        }

                    }
                }

                else
                {
                    var TripRegistrationEditing = new PackageRegistrationEditingCommand
                    {
                        PackageRegistrationId = request.Id,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        Adults = request.Adults,
                        Children = request.Children,
                        CurrentUserId = request.CurrentUserId,
                    };
                    await _mediator.Send(TripRegistrationEditing);
                }


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
