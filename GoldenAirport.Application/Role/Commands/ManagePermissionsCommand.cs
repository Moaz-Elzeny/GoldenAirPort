using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Role.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GoldenAirport.Application.Role.Commands
{
    public class ManagePermissionsCommand : IRequest<ResponseDto<object>>
    {
        public string RoleId { get; set; }
        public List<CheckBoxDto> SelectedPermissions { get; set; }
    }

    public class ManagePermissionsCommandHandler : IRequestHandler<ManagePermissionsCommand, ResponseDto<object>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManagePermissionsCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<object>> Handle(ManagePermissionsCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId) ?? throw new Exception("Role not found.");
            var roleClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var claim in roleClaims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }

            var selectedClaims = request.SelectedPermissions.Where(c => c.IsSelected).ToList();

            foreach (var claim in selectedClaims)
                await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));


            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "Successfully",
                Result = new
                {
                    role
                }
            });
        }
    }
}
