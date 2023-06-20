using Etqaan.Application.Test;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Etqaan.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : BaseController<WeatherForecastController>
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            _logger.LogWarning("WeatherForecast get method Starting.");

            await Mediator.Send(new TestQuery());
            var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}