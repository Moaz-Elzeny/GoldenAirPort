using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Employees.Commands.Edit.Actions
{
    public class EditDailyGoalCommand : IRequest<ResponseDto<object>>
    {
        public string EmployeeId { get; set; }
        public decimal? Target { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditDailyGoalCommandHandler : IRequestHandler<EditDailyGoalCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditDailyGoalCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditDailyGoalCommand request, CancellationToken cancellationToken)
            {
                var dailyGoal = await _dbContext.DailyGoals.Where(e => e.Employee.AppUserId == request.EmployeeId).FirstOrDefaultAsync(cancellationToken);
                if (dailyGoal == null)
                {
                    var goal = new DailyGoal
                    {
                        EmployeeId = request.EmployeeId,
                        Target = request.Target.Value, 
                        Date = DateTime.Now,
                        Goal = 0,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    };
                    _dbContext.DailyGoals.Add(goal);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Updated Successfully",
                        Result = new
                        {
                            Id = goal.Id
                        }
                    });
                }
                else
                {
                    if (DateTime.Now - dailyGoal.Date >= TimeSpan.FromHours(12))
                    {
                        dailyGoal.Date = DateTime.Now;
                    }
                    dailyGoal.Target = request.Target ?? dailyGoal.Target;
                    dailyGoal.ModificationDate = DateTime.Now;
                    dailyGoal.ModifiedById = request.CurrentUserId;
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Updated Successfully",
                        Result = new
                        {
                            Id = dailyGoal.Id
                        }
                    });
                }

                
            }
        }
    }
}
