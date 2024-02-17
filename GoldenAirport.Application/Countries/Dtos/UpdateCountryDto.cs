using Microsoft.AspNetCore.Http;

namespace GoldenAirport.Application.Countries.Dtos
{
    public class UpdateCountryDto
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public byte? Code { get; set; }
        public IFormFile? Icon { get; set; }
    }
}
