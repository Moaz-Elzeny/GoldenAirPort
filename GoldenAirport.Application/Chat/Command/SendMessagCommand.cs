using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Chat.Command
{
    public class SendMessageCommand : IRequest<ResponseDto<object>>
    {
        public int? ChatId { get; set; }
        public string? Content { get; set; }
        public IFormFile? MediaPath { get; set; }
        public MessageType MessageTypeId { get; set; }
        public string? CurrentUserId { get; set; }
        public string? AdminId { get; set; }
        public string? EmployeeId { get; set; }
        public class SendMessageHandler : IRequestHandler<SendMessageCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IHostingEnvironment _environment;
            private readonly IMediator _mediator;


            public SendMessageHandler(IApplicationDbContext dbContext, IHostingEnvironment environment, IMediator mediator)
            {
                _dbContext = dbContext;
                _environment = environment;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(SendMessageCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.AppUsers.Where(a => a.Id == request.CurrentUserId).FirstOrDefault();

                var chat = await _dbContext.Chats.FindAsync(request.ChatId, cancellationToken);
                
                var message = new ChatMessage
                {
                    ChatId = request.ChatId,
                    Content = request.Content,
                    SenderId = request.CurrentUserId,
                    MessageTypeId = request.MessageTypeId,
                    CreationDate = DateTime.Now,
                    CreatedById = request.CurrentUserId
                };

                switch (request.MessageTypeId)
                {
                    case MessageType.Text:
                        message.Content = request.Content;
                        break;
                    case MessageType.Image:
                        message.MediaPath = await FileHelper.SaveImageAsync(request.MediaPath, _environment);
                        break;
                    case MessageType.Video:
                        message.MediaPath = FileHelper.SaveVideo(request.MediaPath, _environment);
                        break;
                    case MessageType.Audio:
                        message.MediaPath = await FileHelper.SaveAudioAsync(request.MediaPath, _environment);
                        break;
                    default:
                        break;
                }

                await _dbContext.ChatMessages.AddAsync(message, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Sent Successfully ✔️",
                    Result = chat.Id
                });
            }
        }
    }
}
