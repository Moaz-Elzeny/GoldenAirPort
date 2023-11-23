//using GoldenAirport.Application.RegistrationsEditing.Commands;
//using GoldenAirport.Application.RegistrationsEditing.Queries;
//using Microsoft.AspNetCore.Mvc;

//namespace GoldenAirport.WebAPI.Controllers
//{
//    [ApiController]
//    [Route("api/v{version:apiVersion}/[controller]")]
//    public class RegistrationEditingController : BaseController<RegistrationEditingController>
//    {
//        public RegistrationEditingController() { }


//        [HttpGet("TripRegistrationEditingById")]
//        public async Task<IActionResult> TripRegistrationEditingByIdQuery(int id)
//        {
//            var query = new TripRegistrationEditingByIdQuery
//            {
//                Id = id
//            };
//            var result = await Mediator.Send(query);
//            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
//        }

        
//        [HttpGet("PackageRegistrationEditingById")]
//        public async Task<IActionResult> PackageRegistrationEditingById(int id)
//        {
//            var query = new PackageRegistrationEditingByIdQuery
//            {
//                Id = id
//            };
//            var result = await Mediator.Send(query);
//            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
//        }



//        [HttpPost("TripRegistrationEditing")]
//        public async Task<IActionResult> TripRegistrationEditing(TripRegistrationEditingCommand command)
//        {
//            command.CurrentUserId = CurrentUserId;

//            var result = await Mediator.Send(command);

//            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);

//        }


//        [HttpPost("PackageRegistrationEditing")]
//        public async Task<IActionResult> PackageRegistrationEditing(PackageRegistrationEditingCommand command)
//        {
//            command.CurrentUserId = CurrentUserId;

//            var result = await Mediator.Send(command);

//            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);

//        }
//    }
//}
