using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Role.DTOs;
using GoldenAirport.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GoldenAirport.Application.Role.Commands
{
    public class ManagePermissionsCommand : IRequest<ResponseDto<object>>
    {
        public string UserId { get; set; }
        public List<CheckBoxDto> SelectedPermissions { get; set; }
    }

    public class ManagePermissionsCommandHandler : IRequestHandler<ManagePermissionsCommand, ResponseDto<object>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;


        public ManagePermissionsCommandHandler(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ResponseDto<object>> Handle(ManagePermissionsCommand request, CancellationToken cancellationToken)
        {
            var role = await _userManager.FindByIdAsync(request.UserId) ?? throw new Exception("Role not found.");
            var roleClaims = await _userManager.GetClaimsAsync(role);

            foreach (var claim in roleClaims)
            {
                await _userManager.RemoveClaimAsync(role, claim);
            }

            var selectedClaims = request.SelectedPermissions.Where(c => c.IsSelected).ToList();

            foreach (var claim in selectedClaims)
                await _userManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));


            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "Successfully",
                Result = new
                {
                    role.Id
                }
            });
        }
    }
}
