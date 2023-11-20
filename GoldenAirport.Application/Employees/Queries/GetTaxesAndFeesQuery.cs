using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Employees.Queries
{
    public class GetTaxesAndFeesQuery : IRequest<ResponseDto<object>>
    {
        public string Id { get; set; }
        public UserType UserType { get; set; }
        public class GetTaxesAndFeesQueryHandler : IRequestHandler<GetTaxesAndFeesQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTaxesAndFeesQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTaxesAndFeesQuery request, CancellationToken cancellationToken)
            {

                var userDetails = new Domain.Entities.AdminDetails();
                var employee = new Employee();

                switch (request.UserType)
                {
                    case UserType.SuperAdmin:
                        userDetails = await _dbContext.AdminDetails.Where(u => u.AppUserId == request.Id).FirstOrDefaultAsync();
                        break;
                    case UserType.Employee:
                        employee = await _dbContext.Employees.Where(u => u.AppUserId == request.Id).FirstOrDefaultAsync();
                        userDetails = await _dbContext.AdminDetails.Where(u => u.AppUserId == employee.CreatedById).FirstOrDefaultAsync();


                        break;
                }
                var TaxesAndFees = employee.ServiceFees + userDetails.ServiceFees + userDetails.TaxValue;
                   


                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Taxes And Fees",
                    Result = TaxesAndFees

                });
            }
        }
    }
}
