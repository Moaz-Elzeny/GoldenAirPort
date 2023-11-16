using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Queries
{
    public class GetTripRegistrationByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }


        public class GetTripRegistrationByIdQueryHandler : IRequestHandler<GetTripRegistrationByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripRegistrationByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTripRegistrationByIdQuery request, CancellationToken cancellationToken)
            {

                var query = _dbContext.TripRegistrations
                    .Include(r => r.Adults)
                    .AsQueryable();

                var TitleValues = Enum.GetValues<Title>();

                var TripRegistrations = await query
                    .Where(t => t.Id == request.Id)
                    .Select(t => new GetTripRegistrationDto
                    {
                        Id = t.Id,
                        TripId = t.TripId,
                        AdultCost = t.AdultCost,
                        ChildCost = t.ChildCost,
                        AdminFees = t.AdminFees ?? 0,
                        EmployeeFees = t.EmployeeFees,
                        Taxes = t.Taxes,
                       //OtherFees = t.OutherFees,
                        TotalAmount = t.TotalAmount,
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,

                        Title = t.Adults.Select(a => a.Title).FirstOrDefault(),
                        TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>(t.Adults.Select(a => a.Title).FirstOrDefault()),
                        FirstName = t.Adults.Select(a => a.FirstName).FirstOrDefault(),
                        LastName = t.Adults.Select(a => a.LastName).FirstOrDefault(),
                        AdultPassportNo = t.Adults.Select(a => a.PassportNo).FirstOrDefault(),
                        DateOfBirth = t.Adults.Select(a => a.DateOfBirth).FirstOrDefault(),
                        NoOfAdults = t.Adults.Count(),
                        ChildPassportNo = t.Children.Select(c => c.PassportNo).FirstOrDefault(),

                    }).ToListAsync(cancellationToken);

                if (TripRegistrations.Count != 0)
                {
                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Trip Registration!",
                        Result = new
                        {
                            TripRegistrations
                        }
                    });
                }
                return ResponseDto<object>.Failure(new ErrorDto()
                {
                    Message = "Something Error!",
                    Code = 101
                });
            }
        }
    }
}
