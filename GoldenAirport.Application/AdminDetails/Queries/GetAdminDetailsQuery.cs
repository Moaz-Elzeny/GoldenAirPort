using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;

namespace GoldenAirport.Application.AdminDetails.Queries
{
    public class GetAdminDetailsQuery : IRequest<ResponseDto<object>>
    {
        public string UserId { get; set; } 
        public class GetAdminDetailsQueryHandler : IRequestHandler<GetAdminDetailsQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetAdminDetailsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetAdminDetailsQuery request, CancellationToken cancellationToken)
            {
             

                var adminDetails =await _dbContext.AdminDetails.Where(a => a.AppUserId == request.UserId)
                    .Select(d => new AdminDetailsDto
                    {
                        ServiceFees = d.ServiceFees,
                        TaxValue = byte.Parse($"{d.TaxValue}"),
                        BookingTime = d.BookingTime,
                        PrivacyPolicyAndTerms = d.PrivacyPolicyAndTerms,
                        CompanyDetails = new CompanyDetailsDto
                        {
                            Name = d.Company.Name,
                            ContactPerson = d.Company.ContactPerson,
                            Email = d.Company.Email,
                            PhoneNumber = d.Company.PhoneNumber,
                            Address = d.Company.Address,

                        }
                    }).ToListAsync();


                return ResponseDto<object>.Success(new Helpers.DTOs.ResultDto()
                {
                    Message = "Admin Details",
                    Result = new
                    {
                        adminDetails
                    }
                });
            }
        }
    }
}
