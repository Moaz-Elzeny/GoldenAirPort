using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Queries
{
    public class GetTripRegistrationQuery : IRequest<ResultDto<PaginatedList<GetTripRegistrationDto>>>
    {
        public int PageNumber { get; set; } = 1;
        

        public class GetTripRegistrationQueryHandler : IRequestHandler<GetTripRegistrationQuery, ResultDto<PaginatedList<GetTripRegistrationDto>>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetTripRegistrationQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<PaginatedList<GetTripRegistrationDto>>> Handle(GetTripRegistrationQuery request, CancellationToken cancellationToken)
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
                        PackageCost = t.PackageCost,
                        TaxesAndFees = t.TaxesAndFees,
                        OtherFees = t.OutherFees,
                        TotalAmount = t.TotalAmount,
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,

                        Title = t.Adults.FirstOrDefault().Title,
                        TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>(t.Adults.FirstOrDefault().Title),
                        FirstName = t.Adults.FirstOrDefault().FirstName,
                        LastName = t.Adults.FirstOrDefault().LastName,
                        AdultPassportNo = t.Adults.FirstOrDefault().PassportNo,
                        DateOfBirth = t.Adults.FirstOrDefault().DateOfBirth,
                        

                    }).ToListAsync(cancellationToken);

                var paginatedList = new PaginatedList<GetTripRegistrationDto>
                {
                    Items = TripRegistrations,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };

                return ResultDto<PaginatedList<GetTripRegistrationDto>>.Success(paginatedList, "All TripRegistration");
            }
        }
    }
}
