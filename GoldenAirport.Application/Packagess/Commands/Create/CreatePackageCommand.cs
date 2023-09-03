﻿using GoldenAirport.Application.Common.Models;
using GoldenAirport.Domain.Entities;
using GoldenAirport.Domain.Enums;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Packagess.Commands.Create
{
    public class CreatePackageCommand : IRequest<ResultDto<string>>
    {
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsRefundable { get; set; }
        public decimal Price { get; set; }
        public decimal PriceLessThan2YearsOld { get; set; }
        public decimal PriceLessThan12YearsOld { get; set; }
        public paymentMethod PaymentMethod { get; set; }
        public int CountryId { get; set; }
        public int FromCityId { get; set; }
        public List<int> ToCitiesIds { get; set; }
        public List<string> PackagePlan { get; set; }
        public string? CurrentUserId { get; set; }
    }

    public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, ResultDto<string>>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreatePackageCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultDto<string>> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            var package = new Package
            {
                Name = request.Name,
                StartingDate = request.StartingDate,
                EndingDate = request.EndingDate,
                Price = request.Price,
                PriceLessThan2YearsOld = request.PriceLessThan2YearsOld,
                PriceLessThan12YearsOld = request.PriceLessThan12YearsOld,
                IsRefundable = request.IsRefundable,
                PaymentMethod = request.PaymentMethod,
                CountryId = request.CountryId,
                FromCityId = request.FromCityId,
                CreatedById = request.CurrentUserId,
                CreationDate = DateTime.Now,
            };

            _dbContext.Packages.Add(package);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var cityPackages = new List<CityPackage>();
            foreach (var cityId in request.ToCitiesIds)
            {
                var city = await _dbContext.Cities.FindAsync(cityId, cancellationToken) ?? throw new NotFoundException("City not found.");

                cityPackages.Add(new CityPackage
                {
                    CityId = cityId,
                    PackageId = package.Id,
                    CreatedById = request.CurrentUserId,
                    CreationDate = DateTime.Now,
                });
            }

            await _dbContext.CityPackages.AddRangeAsync(cityPackages, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            if (request.PackagePlan != null && request.PackagePlan.Count > 0)
            {
                var packagePlans = new List<PackagePlan>();
                foreach (var planDescription in request.PackagePlan)
                {
                    packagePlans.Add(new PackagePlan
                    {
                        Description = planDescription,
                        PackageId = package.Id,
                    });
                }

                _dbContext.PackagePlans.AddRange(packagePlans);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return ResultDto<string>.Success("Package Created Successfully!");
        }
    }
}
