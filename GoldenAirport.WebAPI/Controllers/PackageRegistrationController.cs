﻿using GoldenAirport.Application.PackageRegistrations.Commands.Create;
using GoldenAirport.Application.PackageRegistrations.Commands.Edit;
using GoldenAirport.Application.PackageRegistrations.Dtos;
using GoldenAirport.Application.PackageRegistrations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PackageRegistrationController : BaseController<PackageRegistrationController>
    {
        public PackageRegistrationController() { }

        [HttpGet("fetch")]
        public async Task<IActionResult> GetAllTrips(int pageNumber)
        {
            var query = new GetPackageRegistrationsQuery
            {
                PageNumber = pageNumber,
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpGet("fetch1")]
        public async Task<IActionResult> GetPackageById(int id)
        {
            var query = new GetPackageRegistrationByIdQuery
            {
                Id = id
            };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatePackageRegistrationCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            
            var result = await Mediator.Send(command);

            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromHeader] int Id, EditPackageRegistrationDto dto)
        {
            var command = new EditPackageRegistrationCommand
            {
                Id = Id,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Adults = dto.Adult,
                Children = dto.Child,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
        
        [HttpPut("ApprovePackageRegistrationEditing")]
        public async Task<IActionResult> ApprovePackageRegistrationEditing([FromHeader] int Id, bool Approve)
         {
            var command = new ApprovePackageRegistrationEditingCommand
            {
                PackageRegistrationId = Id,
                Approve = Approve,
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

    }
}