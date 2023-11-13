using GoldenAirport.Application.Chat.Dtos;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Chat.Queries
{
    public class GetChatMessageQuery : IRequest<ResponseDto<object>>
    {
        public int ChatId { get; set; }
        public class GetChatMessageHandler : IRequestHandler<GetChatMessageQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbcontext;

            public GetChatMessageHandler(IApplicationDbContext dbcontext)
            {
                _dbcontext = dbcontext;
            }

            public async Task<ResponseDto<object>> Handle(GetChatMessageQuery request, CancellationToken cancellationToken)
            {
                //var user = await _dbcontext.AppUsers.FindAsync(request.UserId, cancellationToken) ?? throw new NotFoundException("User not found");
                //var chatName = $"{user.FirstName} {user.LastName}" ;
                var chatMessage = await _dbcontext.ChatMessages
                    .Include(c => c.Chat)
                    .Where(c => c.ChatId == request.ChatId)
                    //.Where(e => e.Chat.AdminId == request.UserId || e.Chat.EmployeeId == request.UserId)
                    .OrderBy(d => d.CreationDate)
                    .Select(m => new MessageInfoDto
                    {
                        Message = m.Content ?? string.Empty,
                        MediaPath = m.MediaPath ?? string.Empty,
                        SenderId = m.SenderId,
                        SenderName = m.Sender.FirstName+" "+m.Sender.LastName,
                        CreationDate = m.CreationDate,
                    }).ToListAsync(cancellationToken);

                //var chatName = $"{chatMessage.c.FirstName} {user.LastName}";

                var result = new ChatMessageDto
                {
                    //UserId = request.UserId,
                    UserName = chatMessage.Select(c => c.SenderName).FirstOrDefault(),
                    MessagesInfos = chatMessage

                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Message",
                    Result = new
                    {
                        result
                    }
                });
            }
        }
    }
}
