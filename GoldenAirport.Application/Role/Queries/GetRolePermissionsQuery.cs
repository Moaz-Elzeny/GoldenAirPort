using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Role.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Role.Queries
{
    public class GetRolePermissionsQuery : IRequest<ResponseDto<object>>
    {
        public string UserId { get; set; }

        public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, ResponseDto<object>>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<AppUser> _userManager;


            public GetRolePermissionsQueryHandler(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
            {
                _roleManager = roleManager;
                _userManager = userManager;
            }

            public async Task<ResponseDto<object>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
            {
                var role = await _userManager.FindByIdAsync(request.UserId) ?? throw new NotFoundException("Role not found");

                var roleClaims = await _userManager.GetClaimsAsync(role);
                var allClaims = Infrastructure.Permissions.GenerateAllPermissions();

                var allPermissions = allClaims.Select(p => new
                {
                    Module = p.Split('.')[1],
                    Permission = p.Split('.')[2],
                    IsSelected = roleClaims.Any(c => c.Value == p)
                }).ToList();


                var allPermissionsFormat = allClaims.Select(p => new CheckBoxDto
                {
                    DisplayValue = p,
                    IsSelected = roleClaims.Any(c => c.Type == "Permission" && c.Value == p)
                }).ToList();


                var Result = new
                {
                    UserId = request.UserId,
                    UserName = role.FirstName + "" + role.LastName,
                    //RoleClaims = allPermissions,
                    RoleClaimsFormat = allPermissionsFormat,
                };


                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Permission",
                    Result = new
                    {
                        Result
                    }
                });
            }
        }
    }
}
