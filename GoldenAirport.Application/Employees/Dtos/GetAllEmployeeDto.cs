using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Employees.Dtos
{
    public class GetAllEmployeeDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }       
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public UserType? UserType { get; set; }
        public decimal? ServiceFees { get; set; }
        public decimal? DailyGoal { get; set; }
        public string? ProfilePicture { get; set; }
        public bool? IsActive { get; set; }
        public int? AgentCode { get; set; }
        public int? CountryCode { get; set; }
        public DateTime LastLogin { get; set; }
        public decimal? Balance { get; set; }
        //public decimal DailyGoal { get; set; }
        //public DateTime Date { get; set; }
        //public paymentMethod PaymentMethod { get; set; }
    }
}
