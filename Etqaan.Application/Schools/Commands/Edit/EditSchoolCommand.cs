using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.Users.Commands.EditUser;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Schools.Commands.Edit
{
    public class EditSchoolCommand : IRequest<ResultDto<string>>
    {
        public string? SchoolId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CurrentUserId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? NationalIdNumber { get; set; }
        public Religion? Religion { get; set; }
        public string? AddressDetails { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public UserType? UserType { get; set; }
        public int? NationalityId { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public IFormFile? LogoImage { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public OrganizationType? OrganizationType { get; set; }
        public LearningSystem? LearningSystem { get; set; }
        public int? StudentCapacityId { get; set; }
        public int? TeachersCount { get; set; }
        public int? ClassesCount { get; set; }
        public int? SubscriptionId { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public int? SubscriptionPeriodId { get; set; }
        public decimal? SubscriptionPrice { get; set; }

        public class EditSchoolCommandHandler : IRequestHandler<EditSchoolCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;
            private readonly IHostingEnvironment _environment;

            public EditSchoolCommandHandler(IApplicationDbContext dbContext, IMediator mediator, IHostingEnvironment environment)
            {
                _dbContext = dbContext;
                _mediator = mediator;
                _environment = environment;
            }

            public async Task<ResultDto<string>> Handle(EditSchoolCommand request, CancellationToken cancellationToken)
            {
                var school = await _dbContext.Schools.FindAsync(request.SchoolId);

                if (school == null)
                {
                    return ResultDto<string>.Failure("School not found.");
                }

                // Update User Of School
                var editUserCommand = new EditUserCommand
                {
                    UserId = school.AppUserId,
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

                // Update school data
                if (request.NameAr != null)
                    school.NameAr = request.NameAr;

                if (request.NameEn != null)
                    school.NameEn = request.NameEn;

                if (request.LogoImage != null)
                {
                    if (!string.IsNullOrEmpty(school.LogoImage))
                    {
                        FileHelper.DeleteFile(school.LogoImage, _environment);
                    }

                    school.LogoImage = await FileHelper.SaveImageAsync(request.ProfilePicture, _environment);
                }


                if (request.CountryId != null)
                    school.CountryId = request.CountryId.Value;

                if (request.CityId != null)
                    school.CityId = request.CityId.Value;

                if (request.OrganizationType != null)
                    school.OrganizationType = request.OrganizationType.Value;

                if (request.LearningSystem != null)
                    school.LearningSystem = request.LearningSystem.Value;

                if (request.StudentCapacityId != null)
                    school.StudentCapacityId = request.StudentCapacityId.Value;

                if (request.TeachersCount != null)
                    school.TeachersCount = request.TeachersCount.Value;

                if (request.ClassesCount != null)
                    school.ClassesCount = request.ClassesCount.Value;

                if (request.SubscriptionId != null)
                    school.SubscriptionId = request.SubscriptionId.Value;

                if (request.SubscriptionStartDate != null)
                    school.SubscriptionStartDate = request.SubscriptionStartDate.Value;

                if (request.SubscriptionPeriodId != null)
                    school.SubscriptionPeriodId = request.SubscriptionPeriodId.Value;

                if (request.SubscriptionPrice != null)
                    school.SubscriptionPrice = request.SubscriptionPrice.Value;

                school.ModifiedById = request.CurrentUserId;
                school.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success("School Updated Successfully!");
            }
        }
    }
}
