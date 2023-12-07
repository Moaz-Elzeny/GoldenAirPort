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

        [HttpGet("GetAllChats")]
        public async Task<ActionResult<List<AllChatsDto>>> GetAllChats([FromQuery] string? search)
        {
            var query = new GetAllChatsQuery { Search = search };
            var result = await Mediator.Send(query);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpGet("GetChatMessageByChatId")]
        public async Task<ActionResult<List<ChatMessageDto>>> GetChatMessageByUserId(int Id)
        {
            var chatMessageDto = new GetChatMessageQuery { ChatId = Id};
            var result = await Mediator.Send(chatMessageDto);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("GetChatId")]
        public async Task<IActionResult> GetChatId([FromForm] CreateChatCommand command)
        {
            command.CurrentUserId = CurrentUserId;
            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromForm]SendMessageDto dto)
        {
            var senderId = CurrentUserId;
            if (senderId == null)
            {
                return Unauthorized();
            }
            var command = new SendMessageCommand
            {
                Content = dto.Content,
                ChatId = dto.ChatId,
                MediaPath = dto.MediaFile,
                MessageTypeId = dto.MessageType,                
                CurrentUserId = CurrentUserId
            };

            var result = await Mediator.Send(command);
            return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Result);
        }
    }
}
