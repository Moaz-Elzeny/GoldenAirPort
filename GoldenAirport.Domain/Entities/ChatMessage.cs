using GoldenAirport.Domain.Entities.Auth;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Domain.Entities
{
    public class ChatMessage : BaseEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? MediaPath { get; set; }
        public MessageType MessageTypeId { get; set; }
        public int? ChatId { get; set; }
        public string SenderId { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
