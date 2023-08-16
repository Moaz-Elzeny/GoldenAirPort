using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Employees.Dtos
{
    public class UpdateEmployeeDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public UserType? UserType { get; set; }
        public decimal? ServiceFees { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public bool? IsActive { get; set; }
        public int? AgentCode { get; set; }
        public decimal? Balance { get; set; }
        public decimal? DailyGoal { get; set; }
        public paymentMethod? PaymentMethod { get; set; }
    }
}
