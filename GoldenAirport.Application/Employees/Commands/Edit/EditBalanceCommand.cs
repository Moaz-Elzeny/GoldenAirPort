﻿using GoldenAirport.Application.Common.Models;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditBalanceCommand : IRequest<ResultDto<object>>
    {
        public string EmployeeId { get; set; }
        public decimal? Balance { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditBalanceCommandHandler : IRequestHandler<EditBalanceCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditBalanceCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(EditBalanceCommand request, CancellationToken cancellationToken)
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
                return ResultDto<object>.Success(balance.Id, "Balance Updated Successfully!");
            }
        }
    }
}