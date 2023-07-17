using Etqaan.Application.Common.Models;
using Etqaan.Application.Users.Commands.EditUser;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Teachers.Commands.Edit
{
    public class EditTeacherCommand : IRequest<ResultDto<string>>
    {
        public string TeacherId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
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
        public byte? YearsOfExperience { get; set; }
        public string? SchoolId { get; set; }
        public string? CurrentUserId { get; set; }
        public bool? Active { get; set; }

        public class EditTeacherCommandHandler : IRequestHandler<EditTeacherCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;

            public EditTeacherCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ResultDto<string>> Handle(EditTeacherCommand request, CancellationToken cancellationToken)
            {
                var teacher = await _dbContext.Teachers.FindAsync(request.TeacherId);

                if (teacher == null)
                {
                    return ResultDto<string>.Failure("Teacher not found.");
                }

                // Update User Of Teacher
                var editUserCommand = new EditUserCommand
                {
                    UserId = teacher.AppUserId,
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
                    ProfilePicture = request.ProfilePicture,
                    Active = request.Active,
                };

                await _mediator.Send(editUserCommand, cancellationToken);

                // Update teacher data
                if (request.YearsOfExperience != null)
                    teacher.YearsOfExperience = request.YearsOfExperience.Value;


                if (request.SchoolId != null)
                    teacher.SchoolId = request.SchoolId;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("Teacher Updated Successfully!");
            }
        }
    }
}
