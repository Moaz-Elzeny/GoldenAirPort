using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.PackageRegistrations.Commands.Create
{
    public class CreatePackageRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int PackageId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public string? CurrentUserId { get; set; }

        public List<AdultDto> Adult { get; set; }
        public List<ChildDto> Child { get; set; }

        public class CreatePackageRegistrationCommandHandler : IRequestHandler<CreatePackageRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreatePackageRegistrationCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreatePackageRegistrationCommand request, CancellationToken cancellationToken)
            {
                var package = _dbContext.Packages.Where(t => t.Id == request.PackageId).AsQueryable().FirstOrDefault();



                var userDetails = new Domain.Entities.AdminDetails();
                var employee = new Employee();

                switch (request.UserType)
                {
                    case UserType.SuperAdmin:
                        userDetails = await _dbContext.AdminDetails.Where(u => u.AppUserId == request.CurrentUserId).FirstOrDefaultAsync();
                        break;
                    case UserType.Employee:
                        employee = await _dbContext.Employees.Where(u => u.AppUserId == request.CurrentUserId).FirstOrDefaultAsync();
                        userDetails = await _dbContext.AdminDetails.Where(u => u.AppUserId == employee.CreatedById).FirstOrDefaultAsync();

                        break;
                }
                var adultPrice = package.Price;
                var employeeServiceFees = employee.ServiceFees;
                var childPrice = package.ChildPrice;
                var userServiceFees = userDetails.ServiceFees;
                var Taxes = userDetails.TaxValue ?? 14;

                var packageRegistration = new PackageRegistration
                {
                    PackageId = request.PackageId,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    AdultCost = adultPrice,
                    ChildCost = childPrice,
                    AdminFees = userServiceFees,
                    EmployeeFees = employeeServiceFees,
                    Taxes = Taxes,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,

                };


                foreach (var item in request.Adult)
                {
                    packageRegistration.Adults.Add(new Adult()
                    {
                        Title = item.Title.Value,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PassportNo = item.PassportNo,
                        DateOfBirth = DateTime.Now,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    });
                }
                //child
                foreach (var item in request.Child)
                {
                    packageRegistration.Children.Add(new Child()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PassportNo = item.PassportNo,
                        DateOfBirth = DateTime.Now,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    });
                }

                _dbContext.PackageRegistrations.Add(packageRegistration);

                await _dbContext.SaveChangesAsync(cancellationToken);


                package.RemainingGuests += request.Adult.Count() + request.Child.Count();


                await _dbContext.SaveChangesAsync();

                //if (request.UserType == UserType.Employee)
                //{
                //    var goal = _dbContext.DailyGoals.Where(d => d.Date == )
                //}

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully!",
                    Result = packageRegistration.Id

                });
            }
        }
    }
}
