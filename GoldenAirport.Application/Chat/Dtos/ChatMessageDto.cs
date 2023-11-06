namespace GoldenAirport.Application.Chat.Dtos
{
    public class ChatMessageDto
    {
        //public string UserId { get; set; }
        public string UserName { get; set; }
        public List<MessageInfoDto> MessagesInfos { get; set; }
    }

    public class MessageInfoDto
    {
        public string Message { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string MediaPath { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
