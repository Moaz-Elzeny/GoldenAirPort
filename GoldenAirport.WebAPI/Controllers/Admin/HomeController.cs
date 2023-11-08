using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HomeController : ControllerBase
    {
    }
}
