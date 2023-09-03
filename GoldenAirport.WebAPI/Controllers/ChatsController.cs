using GoldenAirport.Application.Chat.Command;
using GoldenAirport.Application.Chat.Dtos;
using GoldenAirport.Application.Chat.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldenAirport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ChatsController : BaseController<ChatsController>
    {
        public ChatsController() 
        {
        
        }

        [HttpGet("GetChatMessageByUserId")]
        public async Task<ActionResult<List<ChatMessageDto>>> GetChatMessageByUserId(string Id)
        {
            var chatMessageDto = new GetChatMessageQuery { UserId = Id};
            return Ok(await Mediator.Send(chatMessageDto));
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromForm]SendMessageDto dto)
        {
            var senderId = CurrentUserId;
            if (senderId == null)
            {
                return Unauthorized();
            }
            var command = new SendMessagCommand
            {
                Content = dto.Content,
                ChatId = dto.ChatId,
                SenderId = senderId,
                MediaPath = dto.MediaFile,
                MessageTypeId = dto.MessageType,
                AdminId = dto.AdminId,
                EmployeeId = dto.EmployeeId,
                CurrentUserId = CurrentUserId
            };
            return Ok(await Mediator.Send(command));
        }
    }
}
