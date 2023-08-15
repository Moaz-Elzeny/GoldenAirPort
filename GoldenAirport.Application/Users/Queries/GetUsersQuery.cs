using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Users.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Users.Queries
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
                ServiceFees = user.ServiceFees,
                UserType = user.UserType,
                ProfilePicture = user.ProfilePicture,
                //Deleted = user.Deleted,
                //Active = user.Active,
                //CreatedById = user.CreatedById,
                //CreationDate = user.CreationDate,
                //ModifiedById = user.ModifiedById,
                //ModificationDate = user.ModificationDate,

            }).ToList();

            return ResultDto<List<UserDto>>.Success(userDtos);
        }
    }

}
