namespace GoldenAirport.Application.Employees.Dtos
{
    public class GetStatementDto
    {
        public int Code { get; set; }
        public DateTime Day { get; set; }
        public string Service { get; set; }
        public decimal Amount { get; set; }
    }
}
