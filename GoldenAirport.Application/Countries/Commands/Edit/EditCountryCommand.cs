using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Helpers.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace GoldenAirport.Application.Countries.Commands.Edit
{
    public class EditCountryCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public byte? Code { get; set; }
        public IFormFile? Icon { get; set; }
        public string? CurrentUserId { get; set; }

        public class EditCountyHandler : IRequestHandler<EditCountryCommand, ResponseDto<object>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IHostingEnvironment _environment;

            public EditCountyHandler(IApplicationDbContext dbContext, IHostingEnvironment environment)
            {
                _dbContext = dbContext;
                _environment = environment;
            }

            public async Task<ResponseDto<object>> Handle(EditCountryCommand request, CancellationToken cancellationToken)
            {
                var country = await _dbContext.Countries.FindAsync(request.Id) ?? throw new NotFoundException("Employee not found.");
                
                if(request.NameAr != null)
                {
                    country.NameAr = request.NameAr;
                }

                if(request.NameEn != null)
                {
                    country.NameEn = request.NameEn;
                }

                if (request.Icon != null)
                {
                    if (!string.IsNullOrEmpty(country.Icon))
                    {
                        FileHelper.DeleteFile(country.Icon, _environment);
                    }
                    country.Icon = await FileHelper.SaveImageAsync(request.Icon, _environment);
                }
                country.ModifiedById = request.CurrentUserId;
                country.ModificationDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Updated Successfully",
                    Result = new
                    {
                        County = country.Id
                    }
                });
            }
        }
    }
}
