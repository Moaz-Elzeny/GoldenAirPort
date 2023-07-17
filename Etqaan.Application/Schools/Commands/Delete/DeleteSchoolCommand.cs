using Etqaan.Application.Common.Models;

namespace Etqaan.Application.Schools.Commands.Delete
{
    public class DeleteSchoolCommand : IRequest<ResultDto<string>>
    {
        public string SchoolId { get; set; }
        public string CurrentUserId { get; set; }
        public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteSchoolCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<string>> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
            {
                var school = await _dbContext.Schools.FindAsync(request.SchoolId);

                if (school == null)
                {
                    return ResultDto<string>.Failure("School not found.");
                }

                school.Deleted = true;
                school.ModificationDate = DateTime.Now;
                school.ModifiedById = request.CurrentUserId;
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("School Deleted Successfully");
            }
        }
    }
}
