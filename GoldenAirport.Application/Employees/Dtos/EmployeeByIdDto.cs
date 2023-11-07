namespace GoldenAirport.Application.Employees.Dtos
{
    public class EmployeeByIdDto
    {
        public int AgentCode { get; set; }
        public decimal ServiceFees { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
