using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.TripRegistrations.Commands.Create
{
    public class CreateAdultCommand : IRequest<ResponseDto<object>>
    {
        public int tripRegistrationId { get;  set; }
        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? AdultPassportNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CurrentUserId { get; set; }

        public class CreateAdultCommandHandler : IRequestHandler<CreateAdultCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateAdultCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(CreateAdultCommand request, CancellationToken cancellationToken)
            {
                var adult = new Adult
                {
                    TripRegistrationId = request.tripRegistrationId,
                    Title = request.Title,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PassportNo = request.AdultPassportNo,
                    DateOfBirth = DateTime.Now,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                };

                _dbContext.Adults.Add(adult);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Created Successfully ✔️",
                    Result = new
                    {
                        adult = adult.Id
                    }
                });
            }
        }
    }
}
