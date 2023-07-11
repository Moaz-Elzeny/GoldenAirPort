using Etqaan.Application.Students.Commands.Create;
using Etqaan.Application.Students.Commands.DeleteStudent;
using Etqaan.Application.Students.DTOs;
using Etqaan.Application.Students.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Etqaan.WebAPI.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentsController : BaseController<StudentsController>
    {
        public StudentsController() { }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents(int pageNumber = 1)
        {
            var query = new GetAllStudentsQuery
            {
                PageNumber = pageNumber
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromForm] CreateStudentCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(string studentId, [FromForm] UpdateStudentDto dto)
        {


            var updateStudentCommand = new UpdateStudentCommand
            {
                StudentId = studentId,
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
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
                SchoolId = dto.SchoolId,
                SchoolGradeId = dto.SchoolGradeId,
                SchoolClassId = dto.SchoolClassId,
                StudentCategory = dto.StudentCategory,
                LearningSystem = dto.LearningSystem,
                ParentId = dto.ParentId,
                StudentIdInSchool = dto.StudentIdInSchool,
                StudentAbility = dto.StudentAbility,
                Accomodation = dto.Accomodation,
                V = dto.V,
                Q = dto.Q,
                NV = dto.NV,
                S = dto.S,
                MeanSAS = dto.MeanSAS,
                CurrentUserId = dto.CurrentUserId,

            };



            var result = await Mediator.Send(updateStudentCommand);

            return Ok(result);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var command = new DeleteStudentCommand
            {
                StudentId = id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
