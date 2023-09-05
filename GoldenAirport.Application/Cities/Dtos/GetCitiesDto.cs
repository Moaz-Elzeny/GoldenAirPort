using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenAirport.Application.Cities.Dtos
{
    public class GetCitiesDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public CountryDto Country { get; set; }
    }
}
