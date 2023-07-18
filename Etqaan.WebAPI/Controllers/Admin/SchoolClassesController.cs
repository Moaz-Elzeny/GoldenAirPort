using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.SchoolClasses.Commands.Create;
using Etqaan.Application.SchoolClasses.Commands.CreateSchoolClass;
using Etqaan.Application.SchoolClasses.Commands.Delete;
using Etqaan.Application.SchoolClasses.Commands.EditSchoolClass;
using Etqaan.Application.SchoolClasses.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Etqaan.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SchoolClassesController : BaseController<SchoolClassesController>
    {

        [HttpGet("GetAllClasses")]
        public async Task<ActionResult<ResultDto<PaginatedList<GradeClassesDto>>>> GetAllSchoolClasses([FromQuery] GetAllSchoolClassesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }



        [HttpPost("CreateClass")]
        public async Task<ActionResult<ResultDto<string>>> CreateSchoolClass(CreateSchoolClassCommand command)
        {
            var validationResult = await new CreateSchoolClassCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await Mediator.Send(command);

            return Ok(result);

        }


        [HttpPut("UpdateClass")]
        public async Task<IActionResult> UpdateSchoolClass(int id, [FromBody] EditSchoolClassDto dto)
        {
            var command = new EditSchoolClassCommand
            {
                SchoolClassId = id,
                SchoolId = dto.SchoolId,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                SchoolGradeId = dto.SchoolGradeId,
                SubjectIds = dto.SubjectIds
            };

            var validationResult = await new EditSchoolClassCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("DeleteClass")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var command = new DeleteSchoolClassCommand
            {
                SchoolClassId = id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

    }
}
