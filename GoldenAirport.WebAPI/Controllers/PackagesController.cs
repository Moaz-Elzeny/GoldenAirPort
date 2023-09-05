using GoldenAirport.Application.Packagess.Commands.Create;
using GoldenAirport.Application.Packagess.Commands.Delete;
using GoldenAirport.Application.Packagess.Commands.Edit;
using GoldenAirport.Application.Packagess.Dtos;
using GoldenAirport.Application.Packagess.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PackagesController : BaseController<PackagesController>
    {
        public PackagesController()
        {
        }

        [HttpGet("AllPackages")]
        public async Task<IActionResult> GetAllPackages
            ([FromQuery] int pageNumber,
            int? FromCity,
            [FromQuery] List<int>? ToCity,
            [FromQuery] DateTime? StartingOn,
            int? Guests
            )
        {
            var query = new GetPackagesQuery
            {
                PageNumber = pageNumber,
                FromCity = FromCity,
                ToCity = ToCity,
                StartingOn = StartingOn,
                Guests = Guests
            };
            var result = await Mediator.Send(query);
            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreatePackageCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var validationResults = await new CreatePackgeCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);

            return result.Errors != null ? BadRequest(result) : Ok(result);

        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromHeader] int Id, [FromForm] UpdatePackageDto dto)
        {
            var command = new EditPackageCommand
            {
                Id = Id,
                Name = dto.Name,
                StartingDate = dto.StartingDate,
                EndingDate = dto.EndingDate,
                Price = dto.Price,
                PriceLessThan2YearsOld = dto.PriceLessThan2YearsOld,
                PriceLessThan12YearsOld = dto.PriceLessThan12YearsOld,
                CountryId = dto.CountryId,
                FromCityId = dto.FromCityId,
                ToCitiesIds = dto.ToCitiesIds,
                PaymentMethod = dto.PaymentMethod,
                IsRefundable = dto.IsRefundable,
                CurrentUserId = CurrentUserId
            };

            var validationResults = await new EditPackageCommandValidator().ValidateAsync(command);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var result = await Mediator.Send(command);
            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleteTrip = new DeletePackageCommand { Id = Id };
            var result = await Mediator.Send(deleteTrip);

            return result.Errors != null ? BadRequest(result) : Ok(result);
        }

        [HttpDelete("DeletePackagePlan")]
        public async Task<IActionResult> DeletePackagePlan(int PackageId, int? PackagePlanId)
        {
            var deletePackagePlan = new DeletePackagePlanCommand
            {
                PackageId = PackageId,
                PackagePlanId = PackagePlanId,
                

            };
            var result = await Mediator.Send(deletePackagePlan);

            return result.Errors != null ? BadRequest(result) : Ok(result);
        }
    }
}
