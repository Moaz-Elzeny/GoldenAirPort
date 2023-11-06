using GoldenAirport.Application.Chat.Dtos;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Chat.Queries
{
    public class GetChatMessageQuery : IRequest<ResultDto<object>>
    {
        public string UserId { get; set; }
        public class GetChatMessageHandler : IRequestHandler<GetChatMessageQuery, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbcontext;

            public GetChatMessageHandler(IApplicationDbContext dbcontext)
            {
                _dbcontext = dbcontext;
            }

            public async Task<ResultDto<object>> Handle(GetChatMessageQuery request, CancellationToken cancellationToken)
            {
                var user = await _dbcontext.AppUsers.FindAsync(request.UserId, cancellationToken) ?? throw new NotFoundException("User not found");
                var chatName = $"{user.FirstName} {user.LastName}" ;
                var chatMessage = await _dbcontext.ChatMessages
                    .Include(c => c.Chat)
                    .Where(e => e.Chat.AdminId == request.UserId || e.Chat.EmployeeId == request.UserId)
                    .OrderBy(d => d.CreationDate)
                    .Select(m => new MessageInfoDto
                    {
                        Message = m.Content ?? string.Empty,
                        MediaPath = m.MediaPath ?? string.Empty,
                        SenderId = m.SenderId,
                        SenderName = m.Sender.FirstName+" "+m.Sender.LastName,
                        CreationDate = m.CreationDate,
                    }).ToListAsync(cancellationToken);

                var result = new ChatMessageDto
                {
                    //UserId = request.UserId,
                    UserName = chatName,
                    MessagesInfos = chatMessage

                };

                return ResultDto<object>.Success(result, "Message");
            }
        }
    }
}
