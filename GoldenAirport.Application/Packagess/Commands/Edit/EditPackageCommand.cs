using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Packagess.Commands.Edit
{
    public class EditPackageCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? ChildPrice { get; set; }
        public int? FromCityId { get; set; }
        public int? ToCityId { get; set; }
        public string? AboutExploreTour { get; set; }
        public string? IsRefundable { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditPackageHandler : IRequestHandler<EditPackageCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;

            public EditPackageHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseDto<object>> Handle(EditPackageCommand request, CancellationToken cancellationToken)
            {
                var package = await _dbContext.Packages.FindAsync(request.Id) ?? throw new NotFoundException("Package not found.");

                package.Name = request.Name ?? package.Name;

                if (request.StartingDate != null)
                {
                    package.StartingDate = request.StartingDate.Value;
                }

                if (request.EndingDate != null)
                {
                    package.EndingDate = request.EndingDate.Value;
                }

                package.Price = request.Price ?? package.Price;
                package.ChildPrice = request.ChildPrice ?? package.ChildPrice;
                package.AboutExploreTour = request.AboutExploreTour ?? package.AboutExploreTour;
                
                package.FromCityId = request.FromCityId ?? package.FromCityId;
                package.ToCityId = request.ToCityId ?? package.ToCityId;

                if (request.IsRefundable != null)
                {
                    package.IsRefundable = bool.Parse(request.IsRefundable);
                }

                package.ModifiedById = request.CurrentUserId;
                package.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully ✔️",
                    Result = new
                    {
                        Package = package.Id
                    }
                });

            }
        }
    }
}
