using GoldenAirport.Application.Common.Models;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<ResultDto<object>>
    {
        public string Id { get; set; }
        public string? CurrentUserId { get; set; }
        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");

                employee.Deleted = true;
                employee.ModificationDate = DateTime.Now;
                employee.ModifiedById = request.CurrentUserId;
                
                var balsnce = employee.Balance;
                balsnce.Deleted = true;
                balsnce.ModificationDate = DateTime.Now;
                balsnce.ModifiedById = request.CurrentUserId;
                
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<object>.Success(employee.Id, "Deleted has been successfully");
            }
        }
    }
}
