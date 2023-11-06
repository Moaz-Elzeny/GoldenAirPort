using GoldenAirport.Application.Common.Models;

namespace GoldenAirport.Application.AdminDetails.Commands
{
    public class UpdateAdminDetailsCommand : IRequest<ResultDto<object>>
    {
        public string UserId { get; set; }
        public decimal? ServiceFees { get; set; }
        public byte? TaxValue { get; set; }
        public byte? BookingTime { get; set; }
        public string? PrivacyPolicyAndTerms { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditEmployeeHandler : IRequestHandler<UpdateAdminDetailsCommand, ResultDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditEmployeeHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResultDto<object>> Handle(UpdateAdminDetailsCommand request, CancellationToken cancellationToken)
            {
                var admin = await _dbContext.AdminDetails.Where(a => a.Company.AppUserId == request.UserId).FirstOrDefaultAsync();

                if (admin == null)
                {
                    var details = new Domain.Entities.AdminDetails
                    {
                        ServiceFees = request.ServiceFees,
                        TaxValue = request.TaxValue,
                        BookingTime = request.BookingTime,
                        PrivacyPolicyAndTerms = request.PrivacyPolicyAndTerms,
                        ModifiedById = request.CurrentUserId,
                        ModificationDate = DateTime.Now
                    };
                    await _dbContext.AdminDetails.AddAsync(details);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                admin.ServiceFees = request.ServiceFees ?? admin.ServiceFees;
                admin.TaxValue = request.TaxValue ?? admin.TaxValue;
                admin.BookingTime = request.BookingTime ?? admin.BookingTime;
                admin.PrivacyPolicyAndTerms = request.PrivacyPolicyAndTerms ?? admin.PrivacyPolicyAndTerms;
                admin.ModifiedById = request.CurrentUserId;
                admin.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResultDto<object>.Success(admin.Id, "Admin Details Updated Successfully!");

            }
        }
    }
}
