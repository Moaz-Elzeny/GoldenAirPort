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
                        PackageName = t.Package.Name,
                        AdultCost = t.AdultCost,
                        ChildCost = t.ChildCost,
                        StartingDate = t.Package.StartingDate,
                        EndingDate = t.Package.EndingDate,
                        Day = t.Package.EndingDate.DayOfYear - t.Package.StartingDate.DayOfYear,
                        Night = (t.Package.EndingDate.DayOfYear - t.Package.StartingDate.DayOfYear) - 1,
                        TaxesAndFees = t.Taxes + t.EmployeeFees + t.AdminFees,
                        TotalAmount = (int)((t.AdultCost * t.Adults.Count()) + (t.ChildCost * t.Children.Count()) + t.AdminFees + t.EmployeeFees + t.Taxes),
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,
                        AboutExploreTour = t.Package.AboutExploreTour,
                        NumberOfAdults = t.Adults.Count(),
                        NumberOfChildren = t.Children.Count(),
                        Adults = t.Adults.Select(a => new AdultTripRegistrationDto
                        {

                            Title = a.Title,
                            TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>(a.Title),
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            AdultPassportNo = a.PassportNo,
                            DateOfBirth = a.DateOfBirth,
                        }).ToList(),
                        Children = t.Children.Select(c => new ChildrenTripRegistrationDto
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            AdultPassportNo = c.PassportNo,
                            DateOfBirth = c.DateOfBirth,
                        }).ToList(),
                        PackagePlans = t.Package.PackagePlans.Select(p => new PackagePlanDto
                        {
                            Id = p.Id,
                            Description = p.Description
                        }).ToList()

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
