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
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public UserType? UserType { get; set; }
        public decimal? ServiceFees { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public bool? IsActive { get; set; }
        public string? CurrentUserId { get; set; }
        public int? AgentCode { get; set; }
        public decimal? Balance { get; set; }
        public decimal? DailyGoal { get; set; }
        public decimal? Target { get; set; }
        public DateTime? Date { get; set; }
        public paymentMethod? PaymentMethod { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? AppUserId { get; set; }
        public class EditEmployeeHandler : IRequestHandler<EditEmployeeCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public EditEmployeeHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResultDto<object>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");

                //Edit user for the employee
                var EditUser = new EditUserCommand()
                {
                    UserId = employee.AppUserId,
                    UserName = request.UserName,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    UserType = request.UserType,
                    ServiceFees = request.ServiceFees,
                    ProfilePicture = request.ProfilePicture,
                    CurrentUserId = request.CurrentUserId,
                    

                };
                var result = await _mediator.Send(EditUser, cancellationToken);

                //Update employee data
                if (request.AgentCode != null)
                {
                    employee.AgentCode = request.AgentCode.Value;
                }

                if (request.Balance != null)
                {
                    employee.Balance = request.Balance.Value;
                }

                if (request.DailyGoal != null)
                {
                    employee.DailyGoal = request.DailyGoal.Value;
                }

                if (request.Target != null)
                {
                    employee.Target = request.Target.Value;
                }

                if (request.Date != null)
                {
                    employee.Date = request.Date.Value;
                }

                if (request.PaymentMethod != null)
                {
                    employee.PaymentMethod = request.PaymentMethod.Value;
                }

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
