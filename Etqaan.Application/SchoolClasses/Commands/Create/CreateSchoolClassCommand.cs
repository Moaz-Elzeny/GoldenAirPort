using Etqaan.Application.Common.Models;
using Etqaan.Domain.Entities;

namespace Etqaan.Application.SchoolClasses.Commands.CreateSchoolClass
{
    public class CreateSchoolClassCommand : IRequest<ResultDto<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SchoolId { get; set; }
        public int SchoolGradeId { get; set; }
        public List<int> SubjectIds { get; set; }
    }

    public class CreateSchoolClassCommandHandler : IRequestHandler<CreateSchoolClassCommand, ResultDto<string>>
    {
        private readonly IApplicationDbContext _context;

        public CreateSchoolClassCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<string>> Handle(CreateSchoolClassCommand request, CancellationToken cancellationToken)
        {
            var schoolClass = new SchoolClass
            {
                NameAr = request.NameAr,
                NameEn = request.NameEn,
                SchoolId = request.SchoolId,
                SchoolGradeId = request.SchoolGradeId,
                CreatedById = "EtqaanAdmin",
                CreationDate = DateTime.Now
            };

            await _context.SchoolClasses.AddAsync(schoolClass, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var schoolClassSubjects = new List<SchoolClassSubject>();

            foreach (var subjectId in request.SubjectIds)
            {
                var subject = await _context.Subjects.FindAsync(subjectId, cancellationToken);
                if (subject == null)
                {
                    return ResultDto<string>.Failure("Subject not found.");
                }

                schoolClassSubjects.Add(new SchoolClassSubject
                {
                    SubjectId = subjectId,
                    SchoolClassId = schoolClass.Id,
                    CreatedById = "EtqaanAdmin",
                    CreationDate = DateTime.Now
                });
            }

            await _context.SchoolClassSubjects.AddRangeAsync(schoolClassSubjects, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultDto<string>.Success(schoolClass.Id.ToString());
        }
    }
}
