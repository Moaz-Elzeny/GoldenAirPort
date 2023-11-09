using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Employees.Commands.Create
{
    public class CreateBalanceCommand : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public decimal? AddBalance { get; set; } = 0;
        public decimal? RebateBalance { get; set; } = 0;
        public string? CurrentUserId { get; set; }

        public class CreateBalanceCommandHandler : IRequestHandler<CreateBalanceCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateBalanceCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
            {
                var balance = await _dbContext.Balances.Where(e => e.EmployeeId == request.EmployeeId).FirstOrDefaultAsync() ?? throw new Exception("Employee Not Found");
                if (request.AddBalance == 0)
                {
                    balance.BalanceAmount = request.RebateBalance.Value - balance.BalanceAmount;

                }

                balance.BalanceAmount = request.AddBalance.Value + balance.BalanceAmount;
                balance.ModificationDate = DateTime.Now;
                balance.ModifiedById = request.CurrentUserId;
                //_dbContext.Balances.Add(balance);
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

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully",
                    Result = new
                    {
                        Balance = balance.Id
                    }
                });

            }
        }
    }
}
