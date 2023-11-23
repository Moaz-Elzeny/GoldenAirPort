namespace GoldenAirport.Application.Notifications.Dtos
{
    public class AdminTripNotificationsDto
    {
        public string? TicketNumber { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public string FromCity { get; set; }
        public List<string> ToCity { get; set; }
        public string PhoneNumber { get; set; }
    }
}
