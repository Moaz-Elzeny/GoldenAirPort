﻿using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Domain.Entities;

namespace GoldenAirport.Application.Packagess.Commands.Create
{
    public class CreatePackageCommand : IRequest<ResponseDto<object>>
    {
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string IsRefundable { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }       
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public string AboutExploreTour { get; set; }
        public List<string> PackagePlan { get; set; }
        public string? CurrentUserId { get; set; }
    }

    public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommand, ResponseDto<object>>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreatePackageCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseDto<object>> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            var package = new Package
            {
                Name = request.Name,
                StartingDate = request.StartingDate,
                EndingDate = request.EndingDate,
                Price = request.AdultPrice,
                ChildPrice = request.ChildPrice,
                IsRefundable = bool.Parse(request.IsRefundable),               
                FromCityId = request.FromCityId,
                ToCityId = request.ToCityId,
                AboutExploreTour = request.AboutExploreTour,
                CreatedById = request.CurrentUserId,
                CreationDate = DateTime.Now,
            };

            _dbContext.Packages.Add(package);
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


            return ResponseDto<object>.Success(new ResultDto()
            {
                Message = "Created Successfully ✔️",
                Result = new
                {
                    Package = package.Id
                }
            });
        }
    }
}
