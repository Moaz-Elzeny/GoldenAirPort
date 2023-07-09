//using Etqaan.Application.Logs.Models;
//using Etqaan.Application.Logs.Queries;
//using Microsoft.AspNetCore.Mvc;

//namespace Etqaan.WebAPI.Controllers
//{
//    [ApiController]
//    [Route("api/v{version:apiVersion}/[controller]")]
//    public class LogsController : BaseController<LogsController>
//    {


//        [HttpGet]
//        public async Task<ActionResult<List<LogEntryDto>>> GetLogEntries()
//        {
//            string filePath = "Logs/logs.json";
//            var query = new GetAllLogEntriesQuery() { FilePath = filePath };
//            var logEntries = await Mediator.Send(query);

//            return Ok(logEntries);
//        }
//    }

//}
