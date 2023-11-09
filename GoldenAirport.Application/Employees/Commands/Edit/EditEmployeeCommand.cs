using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditEmployeeCommand : IRequest<ResponseDto<object>>
    {
        public string Id { get; set; }
        public bool? IsActive { get; set; }
        public decimal? ServiceFees { get; set; }
        public string? CurrentUserId { get; set; }
        //public int? AgentCode { get; set; }
        //public decimal? DailyGoal { get; set; }
        //public DateTime? Date { get; set; }
        //public paymentMethod? PaymentMethod { get; set; }
        //public DateTime? LastLogin { get; set; }
        //public string? AppUserId { get; set; }
        public class EditEmployeeHandler : IRequestHandler<EditEmployeeCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");

               

                //Update employee data

                if (request.ServiceFees != null)
                {
                    employee.ServiceFees = request.ServiceFees.Value;
                }

                if (request.IsActive != null)
                {
                    employee.Active = request.IsActive.Value;
                }

                employee.ModifiedById = request.CurrentUserId;
                employee.ModificationDate = DateTime.Now;

                //if (request.AppUserId != null)
                //{
                //    employee.AppUserId = employee.AppUserId;
                //}
                //if (request.AgentCode != null)
                //{
                //    employee.AgentCode = request.AgentCode.Value;
                //}

                //if (request.DailyGoal != null)
                //{
                //    employee.DailyGoal = request.DailyGoal.Value;
                //}
                //if (request.Date != null)
                //{
                //    employee.Date = request.Date.Value;
                //}

                //if (request.paymentmethod != null)
                //{
                //    employee.paymentmethod = request.paymentmethod.value;
                //}


                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully",
                    Result = new
                    {
                        Employee = employee.Id
                    }
                });

            }
        }
    }
}
