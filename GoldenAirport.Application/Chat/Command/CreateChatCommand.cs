using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Chat.Command
{
    public class CreateChatCommand : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public string? AdminId { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateChatCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateChatCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.AppUsers.Where(a => a.Id == request.CurrentUserId).FirstOrDefault();

                var Chat = await _dbContext.Chats.Where(c => (c.AdminId == request.AdminId || c.AdminId == user.CreatedById) && c.EmployeeId == request.EmployeeId).FirstOrDefaultAsync();
                if (Chat == null)
                {
                    var chat = new Domain.Entities.Chat
                    {
                        EmployeeId = request.EmployeeId,
                        AdminId = request.AdminId ?? user.CreatedById,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    };
                    await _dbContext.Chats.AddAsync(chat, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Chat Id",
                        Result = chat.Id
                    });
                }

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Chat Id",
                    Result = Chat.Id
                });
            }
        }
    }
}
