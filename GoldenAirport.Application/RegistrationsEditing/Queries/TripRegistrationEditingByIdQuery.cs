using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.RegistrationsEditing.Queries
{
    public class TripRegistrationEditingByIdQuery : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }

        public class TripRegistrationEditingByIdQueryHandler : IRequestHandler<TripRegistrationEditingByIdQuery, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public TripRegistrationEditingByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(TripRegistrationEditingByIdQuery request, CancellationToken cancellationToken)
            {

                var query = _dbContext.TripRegistrationsEditing
                    .Include(r => r.AdultsEditing)
                    .AsQueryable();
                var allpackages = await query.CountAsync(cancellationToken);

                var packageRegistrations = await query
                    .Where(t => t.Id == request.Id)
                    .Select(t => new
                    {
                        Id = t.Id,
                        TripRegistrationId = t.TripRegistrationId,
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
                        Message = "Trip Registration",
                        Result = new
                        {
                            packageRegistrations,
                            allpackages
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
