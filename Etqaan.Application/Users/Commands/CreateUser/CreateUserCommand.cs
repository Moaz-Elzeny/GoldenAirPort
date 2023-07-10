using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.Users.DTOs;
using Etqaan.Domain.Entities.Auth;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Etqaan.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ResultDto<UserTokenDto>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string NationalIdNumber { get; set; }
        public Religion Religion { get; set; }
        public string? AddressDetails { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public UserType UserType { get; set; }
        public int NationalityId { get; set; }
        public string? CurrentUserId { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultDto<UserTokenDto>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IHostingEnvironment _environment;

            public CreateUserCommandHandler(UserManager<AppUser> userManager, IHostingEnvironment environment)
            {
                _userManager = userManager;
                _environment = environment;
            }

            public async Task<ResultDto<UserTokenDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new AppUser
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    NationalIdNumber = request.NationalIdNumber,
                    Religion = request.Religion,
                    AddressDetails = request.AddressDetails,
                    UserType = request.UserType,
                    NationalityId = request.NationalityId,
                    CreatedById = "EtqaanAdmin",
                    CreationDate = DateTime.Now,
                    PhoneNumber = request.PhoneNumber,
                };

                if (request.ProfilePicture != null) { user.ProfilePicture = await FileHelper.SaveImageAsync(request.ProfilePicture, _environment); }

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, request.UserType.ToString());

                    var token = JWTHelper.GenerateToken(user.Id, user.UserName, new string[] { request.UserType.ToString() });
                    var userId = user.Id;
                    var userToken = new UserTokenDto { UserId = userId, Token = token };

                    return ResultDto<UserTokenDto>.Success(userToken);
                }
                else
                {
                    return ResultDto<UserTokenDto>.Failure("Failed to create user");
                }
            }
        }
    }
}
