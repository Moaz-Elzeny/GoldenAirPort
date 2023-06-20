using Etqaan.Domain.Entities.Auth;
using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Id { get; set; }
        public string AppUserId { get; set; }
        public string JobTitle { get; set; }
        public byte YearsOfExperience { get; set; }
        public JobType JobType { get; set; }
        public decimal Salary { get; set; }
        public int BankId { get; set; }
        public string BankAccountNumber { get; set; }
        public string IBAN { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}

