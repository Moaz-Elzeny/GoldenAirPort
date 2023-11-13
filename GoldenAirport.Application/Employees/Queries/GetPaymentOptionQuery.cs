using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetPaymentOptionQuery : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public class GetPaymentOptionQueryHandler : IRequestHandler<GetPaymentOptionQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetPaymentOptionQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetPaymentOptionQuery request, CancellationToken cancellationToken)
            {

                var EmployeeId = await _dbContext.paymentOptionEmployee.Select(e => e.EmployeeId).FirstOrDefaultAsync();
                var PaymentOption = await _dbContext.PaymentOptions.Where(e => request.EmployeeId.Contains(EmployeeId))
                    .Select(x => new
                    {
                        NameAr = x.NameAr,
                        NameEn = x.NameEn,
                        Status = x.Status,
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
