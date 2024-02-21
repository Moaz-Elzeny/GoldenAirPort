using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Countries.Dtos
{
    public class UpdateCountryDto
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public short? Code { get; set; }
        public IFormFile? Icon { get; set; }
    }
}
