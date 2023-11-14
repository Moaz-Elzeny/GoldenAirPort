namespace GoldenAirport.Application.Employees.Dtos
{
    public class GetStatementDto
    {
        public int Code { get; set; } = 102030;
        public DateTime Day { get; set; } = DateTime.Now;
        public string Service { get; set; } = "Trip";
        public string Amount { get; set; } = "+100 SAR";
    }
}
