using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.Commands.CreateUser;
using Etqaan.Domain.Entities;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Students.Commands.Create
{
    public class CreateStudentCommand : IRequest<ResultDto<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string NationalIdNumber { get; set; }
        public Religion Religion { get; set; }
        public string? AddressDetails { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public UserType UserType { get; set; }
        public int NationalityId { get; set; }
        public string? CurrentUserId { get; set; }
        public string SchoolId { get; set; }
        public int SchoolGradeId { get; set; }
        public int SchoolClassId { get; set; }
        public StudentCategory StudentCategory { get; set; }
        public LearningSystem LearningSystem { get; set; }
        public string ParentId { get; set; }
        public string StudentIdInSchool { get; set; }
        public StudentAbility StudentAbility { get; set; }
        public Accomodation Accomodation { get; set; }
        public decimal V { get; set; }
        public decimal Q { get; set; }
        public decimal NV { get; set; }
        public decimal S { get; set; }
        public decimal MeanSAS { get; set; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public CreateStudentCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResultDto<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {

                var createUserCommand = new CreateUserCommand
                {
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
                    Password = request.Password,
                    ProfilePicture = request.ProfilePicture,
                };

                var createUserResult = await _mediator.Send(createUserCommand, cancellationToken);
                var student = new Student
                {
                    Id = Guid.NewGuid().ToString(),
                    SchoolId = request.SchoolId,
                    SchoolGradeId = request.SchoolGradeId,
                    SchoolClassId = request.SchoolClassId,
                    StudentCategory = request.StudentCategory,
                    LearningSystem = request.LearningSystem,
                    ParentId = request.ParentId,
                    StudentIdInSchool = request.StudentIdInSchool,
                    StudentAbility = request.StudentAbility,
                    Accomodation = request.Accomodation,
                    V = request.V,
                    Q = request.Q,
                    NV = request.NV,
                    S = request.S,
                    MeanSAS = request.MeanSAS,
                    CreationDate = DateTime.Now,
                    AppUserId = createUserResult.Data.UserId

                };

                _dbContext.Students.Add(student);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success(student.Id);
            }
        }
    }
}
