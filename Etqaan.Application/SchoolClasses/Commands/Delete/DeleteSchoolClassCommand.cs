using Etqaan.Application.Common.Models;

namespace Etqaan.Application.SchoolClasses.Commands.Delete
{
    public class DeleteSchoolClassCommand : IRequest<ResultDto<string>>
    {
        public int SchoolClassId { get; set; }
        public string? CurrentUserId { get; set; }
    }

    public class DeleteSchoolClassCommandHandler : IRequestHandler<DeleteSchoolClassCommand, ResultDto<string>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSchoolClassCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<string>> Handle(DeleteSchoolClassCommand request, CancellationToken cancellationToken)
        {
            var schoolClass = await _context.SchoolClasses.FindAsync(request.SchoolClassId);

            if (schoolClass == null)
            {
                return ResultDto<string>.Failure("School class not found.");
            }

            schoolClass.Deleted = true;
            schoolClass.ModifiedById = request.CurrentUserId;
            schoolClass.ModificationDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return ResultDto<string>.Success(schoolClass.Id.ToString());
        }
    }

}
