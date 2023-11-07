using GoldenAirport.Application.AdminDetails.DTOs;
using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
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
        //public decimal? PriceLessThan12YearsOld { get; set; }
        public int? CountryId { get; set; }
        public int? FromCityId { get; set; }
        public List<int>? ToCitiesIds { get; set; }
        public bool? IsRefundable { get; set; }
        //public paymentMethod? PaymentMethod { get; set; }
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
                //package.PriceLessThan12YearsOld = request.PriceLessThan12YearsOld ?? package.PriceLessThan12YearsOld;
                package.CountryId = request.CountryId ?? package.CountryId;
                package.FromCityId = request.FromCityId ?? package.FromCityId;

                if (request.IsRefundable != null)
                {
                    package.IsRefundable = request.IsRefundable.Value;
                }

                //if (request.PaymentMethod != null)
                //{
                //    package.PaymentMethod = request.PaymentMethod.Value;
                //}

                package.ModifiedById = request.CurrentUserId;
                package.ModificationDate = DateTime.Now;

                if (request.ToCitiesIds != null)
                {
                    var oldCityPackages = _dbContext.CityPackages.Where(c => c.PackageId == package.Id);
                    _dbContext.CityPackages.RemoveRange(oldCityPackages);

                    foreach (var toCityId in request.ToCitiesIds)
                    {
                        var newCity = await _dbContext.Cities.FindAsync(toCityId, cancellationToken) ?? throw new NotFoundException("City not found.");
                        if (newCity != null)
                        {
                            var newCityPackage = new CityPackage
                            {
                                PackageId = package.Id,
                                CityId = toCityId,
                                CreatedById = request.CurrentUserId,
                                CreationDate = DateTime.Now
                            };
                            _dbContext.CityPackages.Add(newCityPackage);
                        }
                    }
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully!",
                    Result = new
                    {
                        Package = package.Id
                    }
                });

            }
        }
    }
}
