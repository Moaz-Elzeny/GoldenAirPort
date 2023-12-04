using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.PackageRegistrations.Dtos;
using GoldenAirport.Application.RegistrationsEditing.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Application.Trips.Dtos;
using GoldenAirport.Domain.Enums;
using System.Globalization;

namespace GoldenAirport.Application.RegistrationsEditing.Queries
{
    public class PackageRegistrationEditingByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }

        public class PackageRegistrationEditingByIdQueryHandler : IRequestHandler<PackageRegistrationEditingByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public PackageRegistrationEditingByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(PackageRegistrationEditingByIdQuery request, CancellationToken cancellationToken)
            {

                var query = _dbContext.PackageRegistrationsEditing
                    .Include(r => r.AdultsEditing)
                    .Include(c => c.ChildrenEditing)
                    .AsSplitQuery()
                    .AsQueryable();

                var packageRegistrations = await query
                    .Where(t => t.Id == request.Id)
                    .Select(t => new PackageRegistrationEditingByIdDto
                    {
                        Id = t.Id,
                        PackageRegistrationId = t.PackageRegistrationId,
                        PackageName = t.PackageRegistration.Package.Name,
                        AdultCost = t.PackageRegistration.AdultCost,
                        ChildCost = t.PackageRegistration.ChildCost,
                        StartingDate = t.PackageRegistration.Package.StartingDate,
                        EndingDate = t.PackageRegistration.Package.EndingDate,
                        Day = t.PackageRegistration.Package.EndingDate.DayOfYear - t.PackageRegistration.Package.StartingDate.DayOfYear,
                        Night = (t.PackageRegistration.Package.EndingDate.DayOfYear - t.PackageRegistration.Package.StartingDate.DayOfYear) - 1,
                        TaxesAndFees = t.PackageRegistration.Taxes + t.PackageRegistration.EmployeeFees + t.PackageRegistration.AdminFees,
                        TotalAmount = (int)((t.PackageRegistration.AdultCost * t.PackageRegistration.Adults.Count()) +
                        (t.PackageRegistration.ChildCost * t.PackageRegistration.Children.Count()) + 
                        t.PackageRegistration.AdminFees + t.PackageRegistration.EmployeeFees + t.PackageRegistration.Taxes),
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,
                        AboutExploreTour = t.PackageRegistration.Package.AboutExploreTour,
                        NumberOfAdults = t.PackageRegistration.Adults.Count(),
                        NumberOfChildren = t.PackageRegistration.Children.Count(),
                        FromCity = new GetFromCityDto
                        {
                            Id = t.PackageRegistration.Package.FromCityId,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.PackageRegistration.Package.City.NameAr : t.PackageRegistration.Package.City.NameEn,
                        },
                        ToCity = new GetCitiesDto
                        {
                            Id = t.PackageRegistration.Package.ToCityId.Value,
                            CityName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? t.PackageRegistration.Package.ToCity.NameAr : t.PackageRegistration.Package.ToCity.NameEn
                        },
                        Adults = t.AdultsEditing.Select(a => new AdultTripRegistrationDto
                        {

                            Title = a.Title,
                            TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>(a.Title),
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            AdultPassportNo = a.PassportNo,
                            DateOfBirth = a.DateOfBirth,
                        }).ToList(),
                        Children = t.ChildrenEditing.Select(c => new ChildrenTripRegistrationDto
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            AdultPassportNo = c.PassportNo,
                            DateOfBirth = c.DateOfBirth,
                        }).ToList(),
                        PackagePlans = t.PackageRegistration.Package.PackagePlans.Select(p => new PackagePlanDto
                        {
                            Id = p.Id,
                            Description = p.Description
                        }).ToList()

                    }).ToListAsync(cancellationToken);

                if (packageRegistrations.Count != 0)
                {
                    return ResponseDto<object>.Success(new ResultDto()
                    {
                        Message = "Package Registration",
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
