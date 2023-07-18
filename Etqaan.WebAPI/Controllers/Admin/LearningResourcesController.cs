using Etqaan.Application.LearningResources.Commands.Create;
using Etqaan.Application.LearningResources.Commands.Delete;
using Etqaan.Application.LearningResources.Commands.Edit;
using Etqaan.Application.LearningResources.Dtos;
using Etqaan.Application.LearningResources.Queries;
using Etqaan.Application.SchoolClasses.Commands.EditSchoolClass;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Etqaan.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LearningResourcesController : BaseController<LearningResourcesController>
    {
        public LearningResourcesController()
        {
        }

        [HttpGet("GetAllLearnResources")]
        public async Task<IActionResult> GetAll([FromQuery]GetAllLearningResourcesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateLearningResource([FromForm] CreateLearningResourceCommand command)
        {
            var validationResult = await new CreateLearningResourceCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLearningResource(int id, [FromForm]UpdateLearningResourceDto dto)
        {
            var command = new EditLearningResourceCommand
            {
                Id = id,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                ResourceFileType = dto.ResourceFileType,
                ResourceTargetedCategory = dto.ResourceTargetedCategory,
                FilePath = dto.FilePath,
                CoverImagePath = dto.CoverImagePath,
                Size = dto.Size,
                SubjectId = dto.SubjectId,
                GradeId = dto.GradeId,
                CurrentUserId = CurrentUserId
            };
            var validationResult = await new EditLearningResourceCommandValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLearningResource(int id)
        {
            var command = new DeleteLearningResourceCommand
            {
                Id = id,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
