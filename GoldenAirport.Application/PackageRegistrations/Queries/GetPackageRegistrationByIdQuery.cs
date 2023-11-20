using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.PackageRegistrations.Dtos;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.PackageRegistrations.Queries
{
    public class GetPackageRegistrationByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }

        public class GetPackageRegistrationByIdQueryHandler : IRequestHandler<GetPackageRegistrationByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetPackageRegistrationByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(GetPackageRegistrationByIdQuery request, CancellationToken cancellationToken)
            {

                var query = _dbContext.PackageRegistrations
                    .Include(r => r.Adults)
                    .AsQueryable();

                var TitleValues = Enum.GetValues<Title>();

                var packageRegistrations = await query
                    .Where(t => t.Id == request.Id)
                    .Select(t => new PackageRegistrationByIdDto
                    {
                        Id = t.Id,
                        PackageId = t.PackageId,
                        AdultCost = t.AdultCost,
                        ChildCost = t.ChildCost,
                        //AdminFees = t.AdminFees ?? 0,
                        //EmployeeFees = t.EmployeeFees,
                        TaxesAndFees = t.Taxes + t.EmployeeFees + t.AdminFees,
                        //OtherFees = t.OutherFees,
                        TotalAmount = (int)((t.AdultCost * t.Adults.Count()) + (t.ChildCost * t.Children.Count()) + t.AdminFees + t.EmployeeFees + t.Taxes),
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
                        Children = t.Children.Select(c => new ChildrenTripRegistrationDto
                        {
                            FirstName = t.Children.Select(a => a.FirstName).FirstOrDefault(),
                            LastName = t.Children.Select(a => a.LastName).FirstOrDefault(),
                            AdultPassportNo = t.Children.Select(a => a.PassportNo).FirstOrDefault(),
                            DateOfBirth = t.Children.Select(a => a.DateOfBirth).FirstOrDefault(),
                        }).ToList(),

                    }).ToListAsync(cancellationToken);

                if (packageRegistrations.Count != 0)
                {
                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Trip Registration!",
                        Result = packageRegistrations
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
