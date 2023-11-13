using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace GoldenAirport.Application.Role.Queries
{
    public class GetAllRolesQuery : IRequest<ResponseDto<object>>
    {
    }

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, ResponseDto<object>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseDto<object>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.Select(r => new { r.Id, r.Name }).ToListAsync(cancellationToken);
            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "All Rolse",
                Result = new
                {
                    roles
                }
            });
        }
    }
}
