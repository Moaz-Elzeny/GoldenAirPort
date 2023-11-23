﻿namespace GoldenAirport.Application.Notifications.Dtos
{
    public class AdminPackageNotificationsDto
    {
        public string? TicketNumber { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string PhoneNumber { get; set; }
    }


}
