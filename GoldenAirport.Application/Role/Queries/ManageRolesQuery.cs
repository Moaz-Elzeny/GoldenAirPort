using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Role.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace GoldenAirport.Application.Role.Queries
{
    public class ManageRolesQuery : IRequest<ResponseDto<object>>
    {
        public string userId { get; set; }
        public class Handler : IRequestHandler<ManageRolesQuery, ResponseDto<object>>
        {

            private readonly UserManager<AppUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            public Handler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
            {

                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<ResponseDto<object>> Handle(ManageRolesQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(request.userId);

                    if (user == null)
                        return null;

                    var roles = await _roleManager.Roles.ToListAsync();

                    var data = new UserRolesDto
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Roles = roles.Select(role => new CheckBoxDto
                        {
                            DisplayValue = role.Name,
                            IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                        }).ToList()
                    };

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Successfully",
                        Result = new
                        {
                            data
                        }
                    });

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
