﻿using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GoldenAirport.Domain.Entities.Auth
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public UserType UserType { get; set; }
        public decimal ServiceFees { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
       
    }
}