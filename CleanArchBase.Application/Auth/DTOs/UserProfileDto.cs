﻿using CleanArchBase.Domain.Enums;

namespace CleanArchBase.Application.Auth.DTOs
{
    public record UserProfileDto
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public DateTime? DateOfBirth { get; init; }
 
        public string AddressDetails { get; init; }
        public UserType UserType { get; init; }
    }
}