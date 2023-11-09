using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetPaymentOptionQuery : IRequest<ResponseDto<object>>
    {
        public class GetPaymentOptionQueryHandler : IRequestHandler<GetPaymentOptionQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetPaymentOptionQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetPaymentOptionQuery request, CancellationToken cancellationToken)
            {

                var PaymentOption = await _dbContext.PaymentOptions
                    .Select(x => new 
                    {
                       NameAr = x.NameAr,
                       NameEn = x.NameEn,
                    }).ToListAsync(cancellationToken);

                

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All employee",
                    Result = new
                    {
                        PaymentOption
                    }
                });
            }
        }
    }
}
