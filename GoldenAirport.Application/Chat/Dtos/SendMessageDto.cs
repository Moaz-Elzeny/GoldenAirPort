using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Chat.Dtos
{
    public class SendMessageDto
    {
        public string? Content { get; set; }
        public int? ChatId { get; set; }
        public IFormFile? MediaFile { get; set; }
        public MessageType MessageType { get; set; }
        public string? AdminId { get; set; }
        public string? EmployeeId { get; set; }
    }
}
