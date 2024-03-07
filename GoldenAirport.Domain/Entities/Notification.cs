using GoldenAirport.Domain.Entities.Auth;

namespace GoldenAirport.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Seen { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
