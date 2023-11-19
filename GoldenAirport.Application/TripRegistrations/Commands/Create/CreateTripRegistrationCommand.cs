using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateTripRegistrationCommand : IRequest<ResponseDto<object>>
    {
        public int TripId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
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
                var trip = _dbContext.Trips.Where(t => t.Id == request.TripId).AsQueryable().FirstOrDefault();
                

                var user = _dbContext.AdminDetails.Where(u => u.AppUserId == request.CurrentUserId).AsQueryable();

                var employee = _dbContext.Employees.Where(u => u.AppUserId == request.CurrentUserId).AsQueryable();

                //var totalAmount = (request.PackageCost * request.AdultIds.Count) + request.TaxesAndFees + request.OtherFees;
                var adultPrice = trip.Price;
                var employeeServiceFees = employee.Select(c => c.ServiceFees).FirstOrDefault();
                var childPrice = trip.ChildPrice;
                var userServiceFees = user.Select(c => c.ServiceFees).FirstOrDefault() ?? 0;
                var Taxes = user.Select(c => c.TaxValue).FirstOrDefault() ?? 14;

                var tripRegistration = new TripRegistration
                {
                    TripId = request.TripId,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    AdultCost = adultPrice ,
                    ChildCost = childPrice,
                    AdminFees = userServiceFees,
                    EmployeeFees = employeeServiceFees,
                    Taxes = Taxes ,
                    TotalAmount = (adultPrice * request.Adult.Count)+ (childPrice*request.Child.Count)+ userServiceFees + employeeServiceFees + Taxes,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                    //OtherFees = request.OtherFees,

                };

                foreach (var item in request.Adult)
                {
                    tripRegistration.Adults.Add(new Domain.Entities.Adult()
                    {
                        Title = item.Title,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PassportNo = item.AdultPassportNo,
                        DateOfBirth = DateTime.Now,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    });
                }
                //child
                foreach (var item in request.Child)
                {
                    tripRegistration.Children.Add(new Domain.Entities.Child()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PassportNo = item.AdultPassportNo,
                        DateOfBirth = DateTime.Now,
                        CreatedById = request.CurrentUserId,
                        CreationDate = DateTime.Now,
                    });
                }

                _dbContext.TripRegistrations.Add(tripRegistration);

                await _dbContext.SaveChangesAsync(cancellationToken);


                trip.RemainingGuests += (request.Adult.Count() + request.Child.Count());
                

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
