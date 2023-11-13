using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Role.DTOs;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Role.Queries
{
    public class GetRolePermissionsQuery : IRequest<ResponseDto<object>>
    {
        public string RoleId { get; set; }

        public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, ResponseDto<object>>
        {
            private readonly RoleManager<IdentityRole> _roleManager;

            public GetRolePermissionsQueryHandler(RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<ResponseDto<object>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByIdAsync(request.RoleId) ?? throw new NotFoundException("Role not found");

                var roleClaims = await _roleManager.GetClaimsAsync(role);
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
                    RoleId = request.RoleId,
                    RoleName = role.Name,
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
