using Etqaan.Application.Common.Models;

namespace Etqaan.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<ResultDto<string>>
    {
        public string StudentId { get; set; }
        public string CurrentUserId { get; set; }
        public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteStudentCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            {
                var student = await _dbContext.Students.FindAsync(request.StudentId);

                if (student == null)
                {
                    return ResultDto<string>.Failure("Student not found.");
                }

                student.Deleted = true;
                student.ModificationDate = DateTime.Now;
                student.ModifiedById = request.CurrentUserId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success(student.Id);
            }
        }
    }
}
