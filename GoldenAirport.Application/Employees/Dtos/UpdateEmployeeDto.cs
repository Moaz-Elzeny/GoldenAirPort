using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Employees.Dtos
{
    public class UpdateEmployeeDto
    {     
        //public string AppUserId { get; set; }
        public bool? IsActive { get; set; }
        public int? AgentCode { get; set; }
        public DateTime? Date { get; set; }
        public paymentMethod? PaymentMethod { get; set; }
        //public decimal? Balance { get; set; }
        //public decimal? DailyGoal { get; set; }
        //public decimal? Target { get; set; }
    }
}
