using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GoldenAirport.Application.Filters
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionAuthorizationHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }



        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
                return;

            // Get the roles of the logged-in user
            var roles = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            // Check if any of the user's roles have the required permission
            var hasPermission = false;
            foreach (var role in roles)
            {
                var roleObj = await _roleManager.FindByNameAsync(role);
                if (roleObj != null)
                {
                    var claims = await _roleManager.GetClaimsAsync(roleObj);
                    hasPermission = claims.Any(c => c.Type == "Permission" && c.Value == requirement.Permission && c.Issuer == "LOCAL AUTHORITY");
                    if (hasPermission)
                        break;
                }
            }

            if (hasPermission)
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
