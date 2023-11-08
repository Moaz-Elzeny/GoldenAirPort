using GoldenAirport.Application.Common.Models;

namespace GoldenAirport.Application.AdminDetails.Queries
{
    public class AdminHomeQuery : IRequest<ResponseDto<object>>
    {
        public string UserId { get; set; }
        public class AdminHomeQueryHandler : IRequestHandler<AdminHomeQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public AdminHomeQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(AdminHomeQuery request, CancellationToken cancellationToken)
            {


                var home = await _dbContext.AppUsers.Where(a => a.Id == request.UserId)
                    .Select(d => new 
                    {
                        lastLogin = d.LastLogin,
                    }).ToListAsync();


                return ResponseDto<object>.Success(new Helpers.DTOs.ResultDto()
                {
                    Message = "Home",
                    Result = new
                    {
                        home
                    }
                });
            }
        }
    }
}
