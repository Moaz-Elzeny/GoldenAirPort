using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Queries
{
    public class GetTripRegistrationQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;


        public class GetTripRegistrationQueryHandler : IRequestHandler<GetTripRegistrationQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripRegistrationQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetTripRegistrationQuery request, CancellationToken cancellationToken)
            {

                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;

                var query = _dbContext.TripRegistrations
                    .Include(r => r.Adults)
                    .AsQueryable();

                var totalCount = await query.CountAsync(cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var TitleValues = Enum.GetValues<Title>();
                var TripRegistrations = await query
                    .Select(t => new GetTripRegistrationDto
                    {
                        Id = t.Id,
                        AdultCost = t.AdultCost,
                        ChildCost = t.ChildCost,
                        AdminFees = t.AdminFees,
                        EmployeeFees = t.EmployeeFees,
                        //NoOfAdults = t.Trip.RemainingGuests,
                        //OtherFees = t.OtherFees,
                        TotalAmount = t.TotalAmount,
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,
                        Adults = t.Adults.Select(a => new AdultTripRegistrationDto
                        {
                            Title = t.Adults.Select(a => a.Title).FirstOrDefault(),
                            TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>(t.Adults.Select(a => a.Title).FirstOrDefault()),
                            FirstName = t.Adults.Select(a => a.FirstName).FirstOrDefault(),
                            LastName = t.Adults.Select(a => a.LastName).FirstOrDefault(),
                            AdultPassportNo = t.Adults.Select(a => a.PassportNo).FirstOrDefault(),
                            DateOfBirth = t.Adults.Select(a => a.DateOfBirth).FirstOrDefault(),
                        }).ToList(),


                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetTripRegistrationDto>
                {
                    Items = TripRegistrations,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "All TripRegistration ",
                    Result = new
                    {
                        result = paginatedList
                    }
                });
            }
        }
    }
}
