namespace GoldenAirport.Application.Employees.Dtos
{
    public class EmployeeByIdDto
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int AgentCode { get; set; }
        //public decimal Balance { get; set; }
        public decimal Target { get; set; }
        public decimal ServiceFees { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
