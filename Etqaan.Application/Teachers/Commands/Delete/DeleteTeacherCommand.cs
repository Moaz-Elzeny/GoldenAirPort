using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.Commands.Delete;

namespace Etqaan.Application.Teachers.Commands.Delete
{
    public class DeleteTeacherCommand : IRequest<ResultDto<string>>
    {
        public string TeacherId { get; set; }
        public string CurrentUserId { get; set; }

        public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public DeleteTeacherCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResultDto<string>> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
            {
                var teacher = await _dbContext.Teachers.FindAsync(request.TeacherId);

                if (teacher == null)
                {
                    return ResultDto<string>.Failure("Teacher not found.");
                }
                // Delete User Of The Teacher
                await _mediator.Send(new DeleteUserCommand { UserId = teacher.AppUserId, CurrentUserId = "EtqaanAdmin" });

                teacher.Deleted = true;
                teacher.ModifiedById = "EtqaanAdmin";
                teacher.ModificationDate = DateTime.Now;
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Teacher Deleted Successfully");
            }
        }
    }
}
