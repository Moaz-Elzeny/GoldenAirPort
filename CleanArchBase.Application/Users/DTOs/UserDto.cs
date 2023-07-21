﻿using CleanArchBase.Domain.Enums;

namespace CleanArchBase.Application.Users.DTOs
{
    public record UserDto
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string? AddressDetails { get; init; }
        public UserType UserType { get; init; }
        public bool Deleted { get; init; }
        public bool Active { get; init; }
        public string CreatedById { get; init; }
        public DateTime CreationDate { get; init; }
        public string? ModifiedById { get; init; }
        public DateTime? ModificationDate { get; init; }
    }



}