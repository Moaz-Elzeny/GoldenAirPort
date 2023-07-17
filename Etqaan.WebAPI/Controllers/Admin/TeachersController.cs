using Etqaan.Application.Teachers.Commands.Create;
using Etqaan.Application.Teachers.Commands.Delete;
using Etqaan.Application.Teachers.Commands.Edit;
using Etqaan.Application.Teachers.DTOs;
using Etqaan.Application.Teachers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Etqaan.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TeachersController : BaseController<TeachersController>
    {
        public TeachersController() { }


        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeachers([FromQuery] GetAllTeachersQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);

        }



        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher([FromForm] CreateTeacherCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher(string teacherId, [FromForm] UpdateTeacherDto dto)
        {
            var command = new EditTeacherCommand
            {
                TeacherId = teacherId,
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                NationalIdNumber = dto.NationalIdNumber,
                Religion = dto.Religion,
                AddressDetails = dto.AddressDetails,
                ProfilePicture = dto.ProfilePicture,
                UserType = dto.UserType,
                NationalityId = dto.NationalityId,
                YearsOfExperience = dto.YearsOfExperience,
                SchoolId = dto.SchoolId,

                CurrentUserId = CurrentUserId
            };


            var result = await Mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher(string teacherId)
        {
            var command = new DeleteTeacherCommand { TeacherId = teacherId };
            var result = await Mediator.Send(command);
            return Ok(result);
        }


    }
}
