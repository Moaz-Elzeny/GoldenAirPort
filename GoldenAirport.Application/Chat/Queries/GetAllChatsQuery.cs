using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Chat.Dtos;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Chat.Queries
{
    public class GetAllChatsQuery : IRequest<ResponseDto<object>>
    {
        public string Search { get; set; }
        public class GetAllChatsHandler : IRequestHandler<GetAllChatsQuery, ResponseDto<object>> 
            {

            private readonly IApplicationDbContext _dbContext;

            public GetAllChatsHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetAllChatsQuery request, CancellationToken cancellationToken)
            {
                var chats = await _dbContext.Chats
                    .Include(c => c.ChatMessages)
                    .Include(e => e.Employee)
                    .ToListAsync();

                var chatDtos = new List<AllChatsDto>();

                var query = request.Search?.ToLower();

                foreach (var chat in chats)
                {
                    var lastMessage = chat.ChatMessages
                        .OrderByDescending(c => c.CreationDate)
                        .FirstOrDefault();

                    if (lastMessage != null)
                    {
                        var allChats = new AllChatsDto
                        {
                            ChatId = chat.Id,
                            UserId = chat.EmployeeId,
                            FirstName = chat.Employee.FirstName,
                            LastName = chat.Employee.LastName,
                            Email = chat.Employee.Email,
                            ProfilePicture = chat.Employee.ProfilePicture,
                            LastMessage = lastMessage.Content ?? string.Empty,
                            LastMessageDate = chat.CreationDate
                        };
                        if(string.IsNullOrEmpty(query) ||
                            allChats.FirstName.ToLower().Contains(query) ||
                            allChats.LastName.ToLower().Contains(query) ||
                            allChats.Email.ToLower().Contains(query) ||
                            allChats.LastMessage.ToLower().Contains(query))
                        {
                            var existingChat = chatDtos.FirstOrDefault(c => c.UserId == chat.EmployeeId);
                            if (existingChat != null)
                            {
                                if(lastMessage.CreationDate > existingChat.LastMessageDate)
                                {
                                    existingChat.LastMessage = allChats.LastMessage;
                                    existingChat.LastMessageDate = allChats.LastMessageDate;
                                }
                            }
                            else
                            {
                                chatDtos.Add(allChats);
                            }
                        }
                    }
                }

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All chats",
                    Result = new
                    {
                        chatDtos
                    }
                });
            }
        }
    }
}
