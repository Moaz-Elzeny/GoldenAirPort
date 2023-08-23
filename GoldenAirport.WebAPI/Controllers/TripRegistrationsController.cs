using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TripRegistrationsController : BaseController<TripRegistrationsController>
    {
        public TripRegistrationsController()
        {
        }


    }
}
