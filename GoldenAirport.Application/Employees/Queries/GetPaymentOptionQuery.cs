using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using System.Globalization;

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

                //var EmployeeId = await _dbContext.paymentOptionEmployee.Where(e => e.Employee.AppUserId == request.EmployeeId).Select(e => e.EmployeeId).FirstOrDefaultAsync();
                var PaymentOption = await _dbContext.PaymentOptions//.Where(e => e.PaymentOptionEmployees.Select(a => a.Employee.AppUserId).FirstOrDefault() == request.EmployeeId)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? x.NameAr : x.NameEn,
                        Status = x.PaymentOptionEmployees.Where(a => a.Employee.AppUserId == request.EmployeeId).Select(s =>s.Status).FirstOrDefault(),
                    }).ToListAsync(cancellationToken);



                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All employee",
                    Result =  PaymentOption
                });
            }
        }
    }
}
