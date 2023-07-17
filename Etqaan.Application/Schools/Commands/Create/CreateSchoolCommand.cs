using Etqaan.Application.Common.Models;
using Etqaan.Application.Helpers;
using Etqaan.Application.Users.Commands.CreateUser;
using Etqaan.Domain.Entities;
using Etqaan.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Schools.Commands.Create
{
    public class CreateSchoolCommand : IRequest<ResultDto<string>>
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
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public IFormFile LogoImage { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public LearningSystem LearningSystem { get; set; }
        public int StudentCapacityId { get; set; }
        public int TeachersCount { get; set; }
        public int ClassesCount { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public int SubscriptionPeriodId { get; set; }
        public decimal SubscriptionPrice { get; set; }

        public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, ResultDto<string>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMediator _mediator;
            private readonly IHostingEnvironment _environment;


            public CreateSchoolCommandHandler(IApplicationDbContext dbContext, IMediator mediator, IHostingEnvironment environment)
            {
                _dbContext = dbContext;
                _mediator = mediator;
                _environment = environment;
            }

            public async Task<ResultDto<string>> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
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

                var school = new School
                {
                    Id = Guid.NewGuid().ToString(),
                    NameAr = request.NameAr,
                    NameEn = request.NameEn,
                    CountryId = request.CountryId,
                    CityId = request.CityId,
                    OrganizationType = request.OrganizationType,
                    LearningSystem = request.LearningSystem,
                    StudentCapacityId = request.StudentCapacityId,
                    TeachersCount = request.TeachersCount,
                    ClassesCount = request.ClassesCount,
                    SubscriptionId = request.SubscriptionId,
                    SubscriptionStartDate = request.SubscriptionStartDate,
                    SubscriptionPeriodId = request.SubscriptionPeriodId,
                    SubscriptionPrice = request.SubscriptionPrice,
                    AppUserId = createUserResult.Data.UserId,
                    CreatedById = "EtqaanAdmin",
                    CreationDate = DateTime.Now,

                };

                if (request.LogoImage != null) { school.LogoImage = await FileHelper.SaveImageAsync(request.ProfilePicture, _environment); }


                _dbContext.Schools.Add(school);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResultDto<string>.Success(school.Id);
            }
        }
    }
}
