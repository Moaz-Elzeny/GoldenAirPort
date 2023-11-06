namespace GoldenAirport.Domain.Entities
{
    public class DailyGoal : BaseEntity2
    {
        public int Id { get; set; }
        public decimal Goal { get; set; }
        public decimal Target { get; set; }
        public DateTime Date { get; set; }

        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
