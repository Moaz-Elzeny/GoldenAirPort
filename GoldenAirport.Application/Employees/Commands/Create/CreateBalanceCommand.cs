using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Employees.Commands.Create
{
    public class CreateBalanceCommand : IRequest<ResultDto<object>>
    {
        public string EmployeeId { get; set; }
        public decimal Balance { get; set; } = 0;
        public string? CurrentUserId { get; set; }

        public class CreateBalanceCommandHandler : IRequestHandler<CreateBalanceCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateBalanceCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
            {
               
                    var balance = new Balance
                    {
                        BalanceAmount = request.Balance,
                        EmployeeId = request.EmployeeId,
                        CreationDate = DateTime.Now,
                        CreatedById = request.CurrentUserId
                    };
                    _dbContext.Balances.Add(balance);
                    await _dbContext.SaveChangesAsync(cancellationToken);


                    var balanceHistory = new BalanceHistory
                    {
                        TransactionAmount = request.Balance,
                        BalanceId = balance.Id,
                        CreationDate = DateTime.Now,
                        CreatedById = request.CurrentUserId
                    };
                    _dbContext.BalanceHistories.Add(balanceHistory);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<object>.Success(balance.Id, "Created Successfully");

            }
        }
    }
}
