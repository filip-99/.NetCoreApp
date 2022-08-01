using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [ApiController]
    [Route("[controller]")]

    // Klasa predstavlja primer kontrolera i nasleđuje kontroler osnovne klase
    // Kasnije će biti izbrisana, jer nije potrebna ovom projektu
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Deklarisan parametar po tipu ILogger
        private readonly ILogger<WeatherForecastController> _logger;

        // Klasa takođe sadrži konstruktor koji ima prethodno deklarisan parametar ILogger
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // Takođe imamo i API krajnju tačku pod nazivom Get() tipa [HttpGet]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
