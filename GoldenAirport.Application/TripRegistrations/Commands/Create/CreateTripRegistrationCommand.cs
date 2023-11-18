using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateTripRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int TripId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateTripRegistrationHandler : IRequestHandler<CreateTripRegistrationCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateTripRegistrationHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateTripRegistrationCommand request, CancellationToken cancellationToken)
            {
                var trip = _dbContext.Trips.Where(t => t.Id == request.TripId).AsQueryable();
                

                var user = _dbContext.AdminDetails.Where(u => u.AppUserId == request.CurrentUserId).AsQueryable();

                var employee = _dbContext.Employees.Where(u => u.AppUserId == request.CurrentUserId).AsQueryable();

                //var totalAmount = (request.PackageCost * request.AdultIds.Count) + request.TaxesAndFees + request.OtherFees;
                var adultPrice = trip.Select(c => c.Price).FirstOrDefault();
                var employeeServiceFees = employee.Select(c => c.ServiceFees).FirstOrDefault();
                var childPrice = trip.Select(c => c.ChildPrice).FirstOrDefault();
                var userServiceFees = user.Select(c => c.ServiceFees).FirstOrDefault() ?? 0;
                var Taxes = user.Select(c => c.TaxValue).FirstOrDefault() ?? 14;

                var tripRegistration = new TripRegistration
                {
                    TripId = request.TripId,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    AdultCost = adultPrice,
                    ChildCost = childPrice,
                    AdminFees = userServiceFees,
                    EmployeeFees = employeeServiceFees,
                    Taxes = Taxes ,

                    TotalAmount = 0,

                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                    //OtherFees = request.OtherFees,

                };

                _dbContext.TripRegistrations.Add(tripRegistration);

                await _dbContext.SaveChangesAsync(cancellationToken);

                
                var AdultNo = tripRegistration.Adults.Count() == 0 ? 1 : tripRegistration.Adults.Count();
                var ChildNo = tripRegistration.Children.Count();

                var r =await trip.FirstOrDefaultAsync();
                r.RemainingGuests = +1;
                

                //var x = AdultNo * adultPrice;
                // Adjust the TotalAmount calculation based on the boolean flags
                tripRegistration.TotalAmount = (adultPrice * AdultNo) +
                    (employeeServiceFees) +
                    (childPrice * ChildNo) +
                    (userServiceFees) + Taxes ;

                await _dbContext.SaveChangesAsync();
               

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
