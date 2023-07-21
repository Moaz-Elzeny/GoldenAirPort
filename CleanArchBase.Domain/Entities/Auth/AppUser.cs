using CleanArchBase.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace CleanArchBase.Domain.Entities.Auth
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressDetails { get; set; }
        public UserType UserType { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
       
    }
}
