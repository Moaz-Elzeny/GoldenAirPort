using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditBalanceCommand : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public decimal? Balance { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditBalanceCommandHandler : IRequestHandler<EditBalanceCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditBalanceCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditBalanceCommand request, CancellationToken cancellationToken)
            {
                var balance = await _dbContext.Balances.Where(e => e.EmployeeId == request.EmployeeId).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Employee Not Found");

                var balanceHistroy = await _dbContext.BalanceHistories.Where(h => h.BalanceId == balance.Id).FirstOrDefaultAsync(cancellationToken);

                if (request.Balance != null)
                {
                    balance.BalanceAmount = (balance.BalanceAmount + request.Balance.Value);
                    balance.ModificationDate = DateTime.Now;
                    balance.ModifiedById = request.CurrentUserId;
                    balanceHistroy.TransactionAmount = request.Balance.Value;
                    balanceHistroy.ModificationDate = DateTime.Now;
                    balanceHistroy.ModifiedById = request.CurrentUserId;
                }

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully",
                    Result = new
                    {
                        Balance = balance.Id
                    }
                });
            }
        }
    }
}
