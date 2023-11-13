using GoldenAirport.Application.Role.DTOs;

namespace GoldenAirport.Application.Role.Queries
{
    public class UserRolesDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CheckBoxDto> Roles { get; set; }
    }
}
