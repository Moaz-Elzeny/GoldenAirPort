using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.DTOs;
using Etqaan.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace Etqaan.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<ResultDto<List<UserDto>>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ResultDto<List<UserDto>>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUsersQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultDto<List<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();

            var userDtos = users.Select(user => new UserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                NationalIdNumber = user.NationalIdNumber,
                Religion = user.Religion,
                AddressDetails = user.AddressDetails,
                ProfilePicture = user.ProfilePicture,
                UserType = user.UserType,
                NationalityId = user.NationalityId,
                Deleted = user.Deleted,
                Active = user.Active,
                CreatedById = user.CreatedById,
                CreationDate = user.CreationDate,
                ModifiedById = user.ModifiedById,
                ModificationDate = user.ModificationDate,

            }).ToList();

            return ResultDto<List<UserDto>>.Success(userDtos);
        }
    }

}
