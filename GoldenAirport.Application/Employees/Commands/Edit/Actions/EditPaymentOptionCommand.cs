using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditPaymentOptionCommand : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }

        public class EditPaymentOptionCommandHandler : IRequestHandler<EditPaymentOptionCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditPaymentOptionCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditPaymentOptionCommand request, CancellationToken cancellationToken)
            {
                var PaymentOption = await _dbContext.PaymentOptions.Where(e => e.EmployeeId == request.EmployeeId).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Employee Not Found");


                if (PaymentOption != null)
                {
                    PaymentOption.NameAr = request.NameAr ?? PaymentOption.NameAr;
                    PaymentOption.NameEn = request.NameEn ?? PaymentOption.NameEn;
                }

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully",
                    Result = new
                    {
                        result = PaymentOption.Id
                    }
                });
            }
        }
    }
}
