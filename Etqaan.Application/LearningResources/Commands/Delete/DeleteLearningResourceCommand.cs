using Etqaan.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Etqaan.Application.LearningResources.Commands.Delete
{
    public class DeleteLearningResourceCommand : IRequest<ResultDto<string>>
    {
        public int Id { get; set; }
        public string CurrentUserId { get; set; }

        public class DeleteLearningResourceHandler : IRequestHandler<DeleteLearningResourceCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _context;

            public DeleteLearningResourceHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ResultDto<string>> Handle(DeleteLearningResourceCommand request, CancellationToken cancellationToken)
            {
                var resource = await _context.LearningResources.FindAsync(request.Id);

                if (resource == null)
                {
                    return ResultDto<string>.Failure("Resource not found.");
                }

                resource.Deleted = true;
                resource.ModificationDate = DateTime.Now;
                resource.ModifiedById = request.CurrentUserId;
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Resource Deleted Successfully");
            }
        }
    }
}
