﻿using CleanArchBase.Application.Common.Models;
using CleanArchBase.Application.Users.DTOs;
using CleanArchBase.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace CleanArchBase.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<ResultDto<List<UserDto>>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ResultDto<List<UserDto>>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetUsersQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultDto<List<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();

            var userDtos = users.Select(user => new UserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AddressDetails = user.AddressDetails,
                UserType = user.UserType,
                Deleted = user.Deleted,
                Active = user.Active,
                CreatedById = user.CreatedById,
                CreationDate = user.CreationDate,
                ModifiedById = user.ModifiedById,
                ModificationDate = user.ModificationDate,

            }).ToList();

            return ResultDto<List<UserDto>>.Success(userDtos);
        }
    }

}