using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditPaymentOptionCommand : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public List<int>? paymentOptionIds { get; set; }
        //public bool? Status { get; set; }

        public class EditPaymentOptionCommandHandler : IRequestHandler<EditPaymentOptionCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditPaymentOptionCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditPaymentOptionCommand request, CancellationToken cancellationToken)
            {
                var PaymentOption = await _dbContext.Employees.Where(e => e.Id == request.EmployeeId).ToListAsync(cancellationToken) ?? throw new Exception("Employee Not Found");

                if (request.paymentOptionIds != null)
                {
                    var payment = new PaymentOptionEmployee();
                    var removeAbout = _dbContext.paymentOptionEmployee.Where(a => a.EmployeeId == request.EmployeeId);
                    _dbContext.paymentOptionEmployee.RemoveRange(removeAbout);

                    foreach (var paymentOption in request.paymentOptionIds)
                    {
                         payment = new PaymentOptionEmployee
                        {
                            EmployeeId = request.EmployeeId,
                            PaymentOptionId = paymentOption,

                        };
                        _dbContext.paymentOptionEmployee.Add(payment);
                    }
                    //var status = await _dbContext.PaymentOptions.Where(p => p.Id == payment.Id).ToListAsync();

                    //foreach (var s in collection)
                    //{

                    //}
                }


                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully",
                    Result = new
                    {
                        result = PaymentOption
                    }
                });
            }
        }
    }
}
