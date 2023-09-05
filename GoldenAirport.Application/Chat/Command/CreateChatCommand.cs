using GoldenAirport.Application.Common.Models;

namespace GoldenAirport.Application.Chat.Command
{
    public class CreateChatCommand : IRequest<ResultDto<object>>
    {
        public string AdminId { get; set; }
        public string EmployeeId { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateChatCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(CreateChatCommand request, CancellationToken cancellationToken)
            {
                var chat = new Domain.Entities.Chat
                {
                    AdminId = request.AdminId,
                    EmployeeId = request.EmployeeId,
                    CreationDate = DateTime.Now,
                    CreatedById = request.CurrentUserId
                };
                await _dbContext.Chats.AddAsync(chat, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<object>.Success(chat ,"Created Successfully");
            }
        }
    }
}
