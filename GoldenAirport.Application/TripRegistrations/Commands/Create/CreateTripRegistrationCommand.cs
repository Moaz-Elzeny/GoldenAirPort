using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateTripRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int TripId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public string? CurrentUserId { get; set; }

        public List<AdultDto> Adult { get; set; }
        public List<ChildDto> Child { get; set; }

        public class CreateTripRegistrationHandler : IRequestHandler<CreateTripRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateTripRegistrationHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateTripRegistrationCommand request, CancellationToken cancellationToken)
            {
                var trip = _dbContext.Trips.Where(t => t.Id == request.TripId).FirstOrDefault();

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



                var adultPrice = trip.Price;
                var employeeServiceFees = employee.ServiceFees;
                var childPrice = trip.ChildPrice;
                var userServiceFees = userDetails.ServiceFees ?? 0;
                var Taxes = userDetails.TaxValue ?? 14;

                var tripRegistration = new TripRegistration
                {
                    TripId = request.TripId,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    AdultCost = adultPrice,
                    ChildCost = childPrice,
                    AdminFees = userServiceFees,
                    EmployeeFees = employeeServiceFees,
                    Taxes = Taxes,
                    TotalAmount = (adultPrice * request.Adult.Count) + (childPrice * request.Child.Count) + userServiceFees + employeeServiceFees + Taxes,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                    //OtherFees = request.OtherFees,

                };

                foreach (var item in request.Adult)
                {
                    tripRegistration.Adults.Add(new Adult()
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
                    tripRegistration.Children.Add(new Child()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PassportNo = item.PassportNo,
                        DateOfBirth = DateTime.Now,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    });
                }

                _dbContext.TripRegistrations.Add(tripRegistration);

                await _dbContext.SaveChangesAsync(cancellationToken);


                trip.RemainingGuests += (request.Adult.Count() + request.Child.Count());


                await _dbContext.SaveChangesAsync();

                if (request.UserType == UserType.Employee)
                {

                    var goal = _dbContext.DailyGoals.Where(d => d.Date.DayOfYear == DateTime.Now.DayOfYear && d.Employee.AppUserId == request.CurrentUserId).FirstOrDefault();

                    if (goal != null)
                    {
                        goal.Goal = goal.Goal + (adultPrice * request.Adult.Count()) + (childPrice * request.Child.Count());
                        goal.ModificationDate = DateTime.Now;
                        goal.ModifiedById = request.CurrentUserId;
                    }
                    else
                    {
                        var newGoal = new DailyGoal
                        {
                            Goal = (adultPrice * request.Adult.Count()) + (childPrice * request.Child.Count()),
                            Date = DateTime.Now,
                            EmployeeId = employee.Id,
                            CreatedById = request.CurrentUserId,
                            CreationDate = DateTime.Now,
                        };
                        await _dbContext.DailyGoals.AddAsync(newGoal);
                    }
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully!",
                    Result = new
                    {
                        TripRegistration = tripRegistration.Id
                    }
                });
            }
        }
    }
}
