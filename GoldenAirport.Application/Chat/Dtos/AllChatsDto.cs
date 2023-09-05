namespace GoldenAirport.Application.Chat.Dtos
{
    public class AllChatsDto
    {
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageDate { get; set; }
    }
}
