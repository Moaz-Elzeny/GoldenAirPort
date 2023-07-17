using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.Schools.Commands.Create;
using Etqaan.Application.Schools.Commands.Delete;
using Etqaan.Application.Schools.Commands.Edit;
using Etqaan.Application.Schools.DTOs;
using Etqaan.Application.Schools.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Etqaan.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SchoolsController : BaseController<SchoolsController>
    {
        public SchoolsController() { }

        [HttpGet("GetAllSchools")]
        public async Task<ActionResult<ResultDto<PaginatedList<SchoolsListDto>>>> GetAllSchools([FromQuery] GetAllSchoolsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateSchool")]
        public async Task<ActionResult<ResultDto<string>>> CreateSchool([FromForm] CreateSchoolCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateSchool")]
        public async Task<IActionResult> UpdateSchool(string id, [FromForm] EditSchoolDto dto)
        {
            var editSchoolCommand = new EditSchoolCommand
            {
                SchoolId = id,
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
                CurrentUserId = CurrentUserId,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                LogoImage = dto.LogoImage,
                CountryId = dto.CountryId,
                CityId = dto.CityId,
                OrganizationType = dto.OrganizationType,
                LearningSystem = dto.LearningSystem,
                StudentCapacityId = dto.StudentCapacityId,
                TeachersCount = dto.TeachersCount,
                ClassesCount = dto.ClassesCount,
                SubscriptionId = dto.SubscriptionId,
                SubscriptionStartDate = dto.SubscriptionStartDate,
                SubscriptionPeriodId = dto.SubscriptionPeriodId,
                SubscriptionPrice = dto.SubscriptionPrice,

            };

            var result = await Mediator.Send(editSchoolCommand);
            return Ok(result);
        }

        [HttpDelete("DeleteSchool")]
        public async Task<IActionResult> DeleteSchool(string id)
        {
            var currentUserId = CurrentUserId;

            var deleteSchoolCommand = new DeleteSchoolCommand
            {
                SchoolId = id,
                CurrentUserId = currentUserId
            };

            var result = await Mediator.Send(deleteSchoolCommand);

            return Ok(result);
        }


    }
}
