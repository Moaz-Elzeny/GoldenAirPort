using GoldenAirport.Application.Role.Commands;
using GoldenAirport.Application.Role.DTOs;
using GoldenAirport.Application.Role.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserAccessController : BaseController<UserAccessController>
    {
        public UserAccessController() { }

        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await Mediator.Send(new GetAllRolesQuery());

            return !roles.IsSuccess ? BadRequest(roles.Error) : Ok(roles.Result);
        }

        //[HttpPost("Update")]
        //public async Task<IActionResult> EditRole(string id, string Name)
        //{
        //    var command = new EditRoleCommand { RoleId = id, Name = Name };
        //    await Mediator.Send(command);

        //    return Ok();
        //}

        [HttpGet("fetch")]

        public async Task<IActionResult> GetRolePermissions(string roleId)
        {
            var query = new GetRolePermissionsQuery { RoleId = roleId };
            var permissions = await Mediator.Send(query);

            return !permissions.IsSuccess ? BadRequest(permissions.Error) : Ok(permissions.Result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateRolePermissions(string roleId, List<CheckBoxDto> RoleClaims)
        {
            var result = await Mediator.Send(new ManagePermissionsCommand
            {
                RoleId = roleId,
                SelectedPermissions = RoleClaims
            });

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


    }
}
