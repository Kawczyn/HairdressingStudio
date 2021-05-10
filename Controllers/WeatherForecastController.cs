using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
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

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray());
        }
        [Route("Plus")]
        [HttpGet]
        public IEnumerable<WeatherForecast> GetPlus()
        {
            var rng = new Random();
            var pogoda = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

            var pp = pogoda.Where(i => i.TemperatureC > 0).ToList();
            return pp;
        }
        [HttpGet("minus")]
        public IActionResult GetMinus()
        {
            var rng = new Random();
            var pogoda = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

            //var pp = pogoda.Where(i => i.TemperatureC < 0).ToList();
            var pp = pogoda.FirstOrDefault(i => i.TemperatureC < 0);
            return Ok(pp);
        }
        [HttpGet("day/{day}")]
        public WeatherForecast Getccc(int day)
        {
            var rng = new Random();
            var pogoda = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

            var pp = pogoda.Where(i => i.Date == DateTime.Today.AddDays(day)).FirstOrDefault();
            return pp;
        }
        [Route("temp/{temp}")]
        [HttpGet]
        public IActionResult GetTemp(int temp)
        {
            var rng = new Random();
            var pogoda = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

            var pp = pogoda.Where(i => i.TemperatureC > temp).ToList();
            return Ok(pp);
        }
    }
}
