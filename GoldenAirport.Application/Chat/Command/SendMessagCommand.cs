using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Chat.Command
{
    public class SendMessagCommand : IRequest<ResponseDto<object>>
    {
        public int? ChatId { get; set; } 
        public string? Content { get; set; }
        public string SenderId { get; set; }
        public IFormFile? MediaPath { get; set; }
        public MessageType MessageTypeId { get; set; }
        public string? CurrentUserId { get; set; }
        public string? AdminId { get; set; }
        public string? EmployeeId { get; set; }
        public class SendMessagHandler : IRequestHandler<SendMessagCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IHostingEnvironment _environment;
            private readonly IMediator _mediator;


            public SendMessagHandler(IApplicationDbContext dbContext, IHostingEnvironment environment, IMediator mediator)
            {
                _dbContext = dbContext;
                _environment = environment;
                _mediator = mediator;
            }

            public async Task<ResponseDto<object>> Handle(SendMessagCommand request, CancellationToken cancellationToken)
            {
                var chat = await _dbContext.Chats.FindAsync(request.ChatId, cancellationToken);

                if (chat == null)
                {
                   var newChat = await _mediator.Send(new CreateChatCommand
                   {
                       AdminId = request.AdminId,
                       EmployeeId = request.EmployeeId,
                       CurrentUserId = request.CurrentUserId,
                   });


                    var messages = new ChatMessage
                    {
                        ChatId = (int?)newChat.Result.Result,
                        Content = request.Content,
                        SenderId = request.SenderId,
                        MessageTypeId = request.MessageTypeId,
                        CreationDate = DateTime.Now,
                        CreatedById = request.CurrentUserId
                    };

                    switch (request.MessageTypeId)
                    {
                        case MessageType.Text:
                            messages.Content = request.Content;
                            break;
                        case MessageType.Image:
                            messages.MediaPath = await FileHelper.SaveImageAsync(request.MediaPath, _environment);
                            break;
                        case MessageType.Video:
                            messages.MediaPath = FileHelper.SaveVideo(request.MediaPath, _environment);
                            break;
                        case MessageType.Audio:
                            messages.MediaPath = await FileHelper.SaveAudioAsync(request.MediaPath, _environment);
                            break;
                        default:
                            break;
                    }

                    await _dbContext.ChatMessages.AddAsync(messages, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Sent Successfully",
                        Result = new
                        {
                            ChatId = messages.ChatId.ToString()
                        }
                    }
                );

                }

                var message = new ChatMessage
                {
                    ChatId = request.ChatId,
                    Content = request.Content,
                    SenderId = request.SenderId,
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
                        message.MediaPath =  FileHelper.SaveVideo(request.MediaPath, _environment);
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
                    Message = "Sent Successfully",
                    Result = new
                    {
                        chat
                    }
                });
            }
        }
    }
}
