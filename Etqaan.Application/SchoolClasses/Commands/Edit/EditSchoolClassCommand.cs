using Etqaan.Application.Common.Models;
using Etqaan.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Etqaan.Application.SchoolClasses.Commands.EditSchoolClass
{
    public class EditSchoolClassCommand : IRequest<ResultDto<string>>
    {
        public int SchoolClassId { get; set; }
        public string? SchoolId { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int? SchoolGradeId { get; set; }
        public List<int>? SubjectIds { get; set; }
    }

    public class EditSchoolClassCommandHandler : IRequestHandler<EditSchoolClassCommand, ResultDto<string>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStringLocalizerFactory _localizerFactory;

        public EditSchoolClassCommandHandler(IApplicationDbContext context, IStringLocalizerFactory localizerFactory)
        {
            _context = context;
            _localizerFactory = localizerFactory;
        }
        public async Task<ResultDto<string>> Handle(EditSchoolClassCommand request, CancellationToken cancellationToken)
        {
            var localizer = _localizerFactory.Create(typeof(EditSchoolClassCommandHandler));

            var schoolClass = await _context.SchoolClasses.FindAsync(request.SchoolClassId);

            if (schoolClass == null)
            {
                var errorMessage = localizer["School class not found."];
                return ResultDto<string>.Failure(errorMessage);
            }

            if (!string.IsNullOrEmpty(request.SchoolId))
            {
                schoolClass.SchoolId = request.SchoolId;
            }

            if (!string.IsNullOrEmpty(request.NameAr))
            {
                schoolClass.NameAr = request.NameAr;
            }

            if (!string.IsNullOrEmpty(request.NameEn))
            {
                schoolClass.NameEn = request.NameEn;
            }

            if (request.SchoolGradeId.HasValue)
            {
                schoolClass.SchoolGradeId = request.SchoolGradeId.Value;
            }

            if (request.SubjectIds != null)
            {
                // Delete existing SchoolClassSubjects for the SchoolClass
                var existingSubjects = _context.SchoolClassSubjects.Where(scs => scs.SchoolClassId == schoolClass.Id);
                _context.SchoolClassSubjects.RemoveRange(existingSubjects);

                // Add new SchoolClassSubjects
                foreach (var subjectId in request.SubjectIds)
                {
                    var subject = await _context.Subjects.FindAsync(subjectId, cancellationToken);
                    if (subject != null)
                    {
                        var schoolClassSubject = new SchoolClassSubject
                        {
                            SubjectId = subjectId,
                            SchoolClassId = schoolClass.Id,
                            CreatedById = "EtqaanAdmin",
                            CreationDate = DateTime.Now
                        };
                        _context.SchoolClassSubjects.Add(schoolClassSubject);
                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return ResultDto<string>.Success(schoolClass.Id.ToString());
        }
    }
}
