using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateChildCommand : IRequest<ResponseDto<object>>
    {
        public int tripRegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AdultPassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateChildCommandHandler : IRequestHandler<CreateChildCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateChildCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateChildCommand request, CancellationToken cancellationToken)
            {
                var child = new Child
                {
                    TripRegistrationId = request.tripRegistrationId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PassportNo = request.AdultPassportNo,
                    DateOfBirth = DateTime.Now,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                };

                _dbContext.Children.Add(child);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully!",
                    Result = new
                    {
                        child = child.Id
                    }
                });
            }
        }
    }
}
