using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Users.Commands.CreateUser;
using GoldenAirport.Application.Users.Commands.EditUser;
using GoldenAirport.Domain.Enums;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditEmployeeCommand : IRequest<ResultDto<object>>
    {
        public string Id { get; set; }
        public bool? IsActive { get; set; }
        public string? CurrentUserId { get; set; }
        public int? AgentCode { get; set; }
        public decimal? Balance { get; set; }
        //public decimal? DailyGoal { get; set; }
        public decimal? Target { get; set; }
        public DateTime? Date { get; set; }
        public paymentMethod? PaymentMethod { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? AppUserId { get; set; }
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

                var balance =await _dbContext.Balances.Where(e => e.EmployeeId == request.Id).FirstOrDefaultAsync(cancellationToken);

                var balanceHistroy = await _dbContext.BalanceHistories.Where(h => h.BalanceId == balance.Id).FirstOrDefaultAsync(cancellationToken);

                //Update employee data
                if (request.AppUserId != null)
                {
                    employee.AppUserId = employee.AppUserId;
                }
                if (request.AgentCode != null)
                {
                    employee.AgentCode = request.AgentCode.Value;
                }

                if (request.Balance != null)
                {
                    balance.BalanceAmount = (balance.BalanceAmount + request.Balance.Value);
                    balance.ModificationDate = DateTime.Now;
                    balance.ModifiedById = request.CurrentUserId;
                    balanceHistroy.TransactionAmount = request.Balance.Value;
                    balanceHistroy.ModificationDate = DateTime.Now;
                    balanceHistroy.ModifiedById = request.CurrentUserId;
                }

                //if (request.DailyGoal != null)
                //{
                //    employee.DailyGoal = request.DailyGoal.Value;
                //}

                if (request.Target != null)
                {
                    employee.Target = request.Target.Value;
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
