using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Employees.Commands.Edit
{
    public class EditEmployeeCommand : IRequest<ResponseDto<object>>
    {
        public string Id { get; set; }
        public string? IsActive { get; set; }
        public decimal? ServiceFees { get; set; }
        public string? CurrentUserId { get; set; }
        public class EditEmployeeHandler : IRequestHandler<EditEmployeeCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.Where(a => a.AppUserId == request.Id).FirstOrDefaultAsync() ?? throw new NotFoundException("Employee not found.");

               

                //Update employee data

                if (request.ServiceFees != null)
                {
                    employee.ServiceFees = request.ServiceFees.Value;
                }

                if (request.IsActive != null)
                {
                    employee.Active = bool.Parse(request.IsActive);
                }

                employee.ModifiedById = request.CurrentUserId;
                employee.ModificationDate = DateTime.Now;


                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully ✔️",
                    Result = new
                    {
                        Employee = employee.Id
                    }
                });

            }
        }
    }
}
