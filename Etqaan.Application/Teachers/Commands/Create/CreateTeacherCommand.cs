using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.Commands.CreateUser;
using Etqaan.Domain.Entities;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Teachers.Commands.Create
{
    public class CreateTeacherCommand : IRequest<ResultDto<string>>
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
        public byte YearsOfExperience { get; set; }
        public string SchoolId { get; set; }

        public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public CreateTeacherCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResultDto<string>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
                // Create user for the Teacher
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

                var teacher = new Teacher
                {
                    Id = Guid.NewGuid().ToString(),
                    YearsOfExperience = request.YearsOfExperience,
                    SchoolId = request.SchoolId,
                    CreatedById = "EtqaanAdmin",
                    CreationDate = DateTime.Now,
                    AppUserId = createUserResult.Data.UserId,
                };

                _dbContext.Teachers.Add(teacher);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success(teacher.Id);
            }
        }
    }
}
