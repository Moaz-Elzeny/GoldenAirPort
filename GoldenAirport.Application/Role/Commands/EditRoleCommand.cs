using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Application.Role.Commands
{
    public class EditRoleCommand : IRequest<ResponseDto<object>>
    {
        public string RoleId { get; set; }
        public string Name { get; set; }

        public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _context;
            private readonly RoleManager<IdentityRole> _roleManager;

            public EditRoleCommandHandler(IApplicationDbContext context, RoleManager<IdentityRole> roleManager)
            {
                _context = context;
                _roleManager = roleManager;
            }

            public async Task<ResponseDto<object>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByIdAsync(request.RoleId);

                if (role != null)
                {
                    role.Name = request.Name;
                    await _roleManager.UpdateAsync(role);
                }

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
}
