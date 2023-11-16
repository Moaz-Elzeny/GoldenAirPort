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
       
        //public decimal? AdminFees { get; set; }
        //public decimal? EmployeeFees { get; set; }
        //public decimal Taxes { get; set; }
        //public decimal OtherFees { get; set; }

        //public Title Title { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string? AdultPassportNo { get; set; }
        //public DateTime DateOfBirth { get; set; }

        //public string? ChildPassportNo { get; set; }
        //public List<int> AdultIds { get; set; } 
        //public int NoOfChildren { get; set; } = 1;
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

                var tripRegistration = new TripRegistration
                {
                    TripId = request.TripId,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    AdultCost = trip.Select(c => c.Price).FirstOrDefault(),
                    ChildCost = trip.Select(c => c.ChildPrice).FirstOrDefault(),
                    AdminFees = user.Select(c => c.ServiceFees).FirstOrDefault(),
                    EmployeeFees = employee.Select(c => c.ServiceFees).FirstOrDefault(),
                    Taxes = user.Select(c => c.TaxValue).FirstOrDefault() ?? 14,

                    TotalAmount = 0,

                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                    //OtherFees = request.OtherFees,

                };

                _dbContext.TripRegistrations.Add(tripRegistration);

                await _dbContext.SaveChangesAsync(cancellationToken);

                // var AdultNo = tripRegistration.Adults.Count();
                // var ChildNo = tripRegistration.Children.Count();

                var AdultNo = tripRegistration.Adults.Count() == 0 ? 1 : tripRegistration.Adults.Count();
                var ChildNo = tripRegistration.Children.Count();

                var adultPrice = trip.Select(c => c.Price).FirstOrDefault()  ;
                var employeeServiceFees = employee.Select(c => c.ServiceFees).FirstOrDefault();
                var childPrice = trip.Select(c => c.ChildPrice).FirstOrDefault() ;
                var userServiceFees = user.Select(c => c.ServiceFees).FirstOrDefault() ?? 0 ;

                var x = AdultNo * adultPrice;
                // Adjust the TotalAmount calculation based on the boolean flags
                tripRegistration.TotalAmount = (adultPrice * AdultNo) +
                    (employeeServiceFees) +
                    (childPrice * ChildNo) +
                    (userServiceFees) ;

                await _dbContext.SaveChangesAsync();
                //var EmployeeRegistration = new EmployeeTripRegistration
                //{
                //    EmployeeId = request.CurrentUserId,
                //    TripRegistration = tripRegistration,
                //};

                //await _dbContext.EmployeeTripRegistrations.AddAsync(EmployeeRegistration);



                //var adult = new Adult
                //{
                //    TripRegistrationId = tripRegistration.Id,
                //    Title = request.Title,
                //    FirstName = request.FirstName,
                //    LastName = request.LastName,
                //    PassportNo = request.AdultPassportNo,
                //    DateOfBirth = DateTime.Now,
                //    CreatedById = request.CurrentUserId,
                //    CreationDate = DateTime.Now,
                //};


                //var adults = new List<Adult>();
                //foreach (var adultId in request.AdultIds)
                //{
                //    //var adult1 = await _dbContext.Adults.FindAsync(adultId, cancellationToken) ?? throw new NotFoundException("Adult not found.");

                //    adults.Add(new Adult
                //    {
                //        TripRegistrationId = tripRegistration.Id,
                //        Id = adultId,
                //        CreatedById = request.CurrentUserId,
                //        CreationDate = DateTime.Now

                //    });
                //}

                //_dbContext.Adults.AddRange(adults);
                //await _dbContext.SaveChangesAsync(cancellationToken);

                //var child = new Child
                //{
                //    TripRegistrationId = tripRegistration.Id,
                //    PassportNo = request.ChildPassportNo,
                //    AgeRange = request.AgeRange
                //};

                //_dbContext.children.Add(child);
                //await _dbContext.SaveChangesAsync(cancellationToken);

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
