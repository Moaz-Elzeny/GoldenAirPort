using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.Commands.EditUser;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

public class UpdateStudentCommand : IRequest<ResultDto<string>>
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public string? NationalIdNumber { get; set; }
    public Religion? Religion { get; set; }
    public string? AddressDetails { get; set; }
    public IFormFile? ProfilePicture { get; set; }
    public UserType? UserType { get; set; }
    public int? NationalityId { get; set; }
    public string? StudentId { get; set; }
    public string? SchoolId { get; set; }
    public int? SchoolGradeId { get; set; }
    public int? SchoolClassId { get; set; }
    public StudentCategory? StudentCategory { get; set; }
    public LearningSystem? LearningSystem { get; set; }
    public string? ParentId { get; set; }
    public string? StudentIdInSchool { get; set; }
    public StudentAbility? StudentAbility { get; set; }
    public Accomodation? Accomodation { get; set; }
    public decimal? V { get; set; }
    public decimal? Q { get; set; }
    public decimal? NV { get; set; }
    public decimal? S { get; set; }
    public decimal? MeanSAS { get; set; }
    public string? CurrentUserId { get; set; }



    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ResultDto<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMediator _mediator;

        public UpdateStudentCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<ResultDto<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _dbContext.Students.FindAsync(request.StudentId, cancellationToken);

            if (student == null)
            {
                return ResultDto<string>.Failure("Student not found.");
            }

            // Update User Of Student
            var editUserCommand = new EditUserCommand
            {
                UserId = student.AppUserId,
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                NationalIdNumber = request.NationalIdNumber,
                Religion = request.Religion,
                AddressDetails = request.AddressDetails,
                UserType = request.UserType,
                NationalityId = request.NationalityId,
                CurrentUserId = request.CurrentUserId,
                PhoneNumber = request.PhoneNumber,
                ProfilePicture = request.ProfilePicture
            };

            await _mediator.Send(editUserCommand, cancellationToken);

            // Update student data
            if (request.SchoolId != null)
                student.SchoolId = request.SchoolId;

            if (request.SchoolGradeId != null)
                student.SchoolGradeId = request.SchoolGradeId.Value;

            if (request.SchoolClassId != null)
                student.SchoolClassId = request.SchoolClassId.Value;

            if (request.StudentCategory != null)
                student.StudentCategory = request.StudentCategory.Value;

            if (request.LearningSystem != null)
                student.LearningSystem = request.LearningSystem.Value;

            if (request.ParentId != null)
                student.ParentId = request.ParentId;

            if (request.StudentIdInSchool != null)
                student.StudentIdInSchool = request.StudentIdInSchool;

            if (request.StudentAbility != null)
                student.StudentAbility = request.StudentAbility.Value;

            if (request.Accomodation != null)
                student.Accomodation = request.Accomodation.Value;

            if (request.V != null)
                student.V = request.V.Value;

            if (request.Q != null)
                student.Q = request.Q.Value;

            if (request.NV != null)
                student.NV = request.NV.Value;

            if (request.S != null)
                student.S = request.S.Value;

            if (request.MeanSAS != null)
                student.MeanSAS = request.MeanSAS.Value;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return ResultDto<string>.Success("Student Updated Successfully!");
        }
    }
}
