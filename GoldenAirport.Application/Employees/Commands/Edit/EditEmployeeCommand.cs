using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Enums;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditEmployeeCommand : IRequest<ResultDto<object>>
    {
        public string Id { get; set; }
        public bool? IsActive { get; set; }
        public string? CurrentUserId { get; set; }
        public int? AgentCode { get; set; }
        //public decimal? DailyGoal { get; set; }
        public decimal? ServiceFees { get; set; }
        public DateTime? Date { get; set; }
        public paymentMethod? PaymentMethod { get; set; }
        public DateTime? LastLogin { get; set; }
        //public string? AppUserId { get; set; }
        public class EditEmployeeHandler : IRequestHandler<EditEmployeeCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");

               

                //Update employee data
                //if (request.AppUserId != null)
                //{
                //    employee.AppUserId = employee.AppUserId;
                //}
                if (request.AgentCode != null)
                {
                    employee.AgentCode = request.AgentCode.Value;
                }

                //if (request.DailyGoal != null)
                //{
                //    employee.DailyGoal = request.DailyGoal.Value;
                //}

                if (request.ServiceFees != null)
                {
                    employee.ServiceFees = request.ServiceFees.Value;
                }

                //if (request.Date != null)
                //{
                //    employee.Date = request.Date.Value;
                //}

                //if (request.PaymentMethod != null)
                //{
                //    employee.PaymentMethod = request.PaymentMethod.Value;
                //}

                if (request.IsActive != null)
                {
                    employee.Active = request.IsActive.Value;
                }

                employee.ModifiedById = request.CurrentUserId;
                employee.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResultDto<object>.Success(employee.Id ,"Employee Updated Successfully!");

            }
        }
    }
}
