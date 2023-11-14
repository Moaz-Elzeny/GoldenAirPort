using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using System.Globalization;

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
                var employee = await _dbContext.Employees.Where(e => e.AppUserId == request.EmployeeId).Select(u => u.Id).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Employee Not Found");

                if (request.paymentOptionIds != null)
                {
                    var payment = new PaymentOptionEmployee();
                    var removeAbout = _dbContext.paymentOptionEmployee.Where(a => a.Employee.AppUserId == request.EmployeeId);
                    _dbContext.paymentOptionEmployee.RemoveRange(removeAbout);

                    foreach (var paymentOption in request.paymentOptionIds)
                    {
                        payment = new PaymentOptionEmployee
                        {
                            EmployeeId = employee,
                            PaymentOptionId = paymentOption,
                            Status = true

                        };
                        _dbContext.paymentOptionEmployee.Add(payment);
                    }
                    //await _dbContext.SaveChangesAsync(cancellationToken);

                    //var f = _dbContext.PaymentOptions.Where(f => f.Status == true).ToList();
                    //f.ForEach(f => f.Status = false);

                    //var paymentOptionId = await _dbContext.PaymentOptions.Where(p => request.paymentOptionIds.Contains(p.Id)).ToListAsync();

                    //foreach (var status in paymentOptionId)
                    //{
                    //    status.Status = true;
                    //}

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Updated Successfully",
                        Result = new
                        {
                            employee
                        }
                    });
                }
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Code = 101,
                    Message = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? " من فضك ادخل وسائل الدفع" : "Please Enter payment Options"
                });
            }
        }
    }
}
