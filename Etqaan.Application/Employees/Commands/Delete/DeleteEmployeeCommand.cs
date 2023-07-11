using Etqaan.Application.Common.Models;

namespace Etqaan.Application.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<ResultDto<string>>
    {
        public string EmployeeId { get; set; }
        public string CurrentUserId { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteEmployeeCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.EmployeeId, cancellationToken);

                if (employee == null)
                {
                    return ResultDto<string>.Failure("Employee not found.");
                }

                // Set the IsDeleted flag to true
                employee.Deleted = true;
                employee.ModificationDate = DateTime.Now;
                employee.ModifiedById = request.CurrentUserId;
                employee.AppUser.Deleted = true;
                employee.AppUser.ModifiedById = request.CurrentUserId;
                employee.AppUser.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Employee deleted successfully.");
            }
        }
    }
}
