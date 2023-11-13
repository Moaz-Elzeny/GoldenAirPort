using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<ResponseDto<object>>
    {
        public string Id { get; set; }
        public string? CurrentUserId { get; set; }
        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");

                employee.Deleted = true;
                employee.ModificationDate = DateTime.Now;
                employee.ModifiedById = request.CurrentUserId;
                
                //var balsnce = employee.Balance;
                //balsnce.Deleted = true;
                //balsnce.ModificationDate = DateTime.Now;
                //balsnce.ModifiedById = request.CurrentUserId;
                
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Deleted Successfully",
                    Result = new
                    {
                        Employee = employee.Id
                    }
                });
            }
        }
    }
}
