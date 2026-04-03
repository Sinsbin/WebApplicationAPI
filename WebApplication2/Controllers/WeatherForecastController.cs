using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;


namespace WebApplication2.Controllers {
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public async Task<DateTime> Get() {
            return DateTime.Now;
        }

        [HttpPost]
        public async Task<string> TextBack() {
            return "testComplete";
        }

    }
}
