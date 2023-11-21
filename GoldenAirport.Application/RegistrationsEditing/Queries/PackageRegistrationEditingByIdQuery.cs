using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;

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
                    .AsQueryable();

                var packageRegistrations = await query
                    .Where(t => t.Id == request.Id)
                    .Select(t => new 
                    {
                        Id = t.Id,
                        PackageRegistrationId = t.PackageRegistrationId,                      
                        Email = t.Email,
                        PhoneNumber = t.PhoneNumber,
                        Adults = t.AdultsEditing.Select(a => new AdultTripRegistrationDto
                        {

                            Title = t.AdultsEditing.Select(a => a.Title).FirstOrDefault(),
                            TitleValue = EnumHelper.GetEnumLocalizedDescription<Title>(t.AdultsEditing.Select(a => a.Title).FirstOrDefault()),
                            FirstName = t.AdultsEditing.Select(a => a.FirstName).FirstOrDefault(),
                            LastName = t.AdultsEditing.Select(a => a.LastName).FirstOrDefault(),
                            AdultPassportNo = t.AdultsEditing.Select(a => a.PassportNo).FirstOrDefault(),
                            DateOfBirth = t.AdultsEditing.Select(a => a.DateOfBirth).FirstOrDefault(),
                        }).ToList(),
                        Children = t.ChildrenEditing.Select(c => new ChildrenTripRegistrationDto
                        {
                            FirstName = t.ChildrenEditing.Select(a => a.FirstName).FirstOrDefault(),
                            LastName = t.ChildrenEditing.Select(a => a.LastName).FirstOrDefault(),
                            AdultPassportNo = t.ChildrenEditing.Select(a => a.PassportNo).FirstOrDefault(),
                            DateOfBirth = t.ChildrenEditing.Select(a => a.DateOfBirth).FirstOrDefault(),
                        }).ToList(),

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
