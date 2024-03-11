using Microsoft.AspNetCore.Mvc;

namespace Credentials.Controllers
{
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var token  = "";
            
            var cookie = Request.Cookies.TryGetValue("session", out token);

            if (!cookie)
            {
                return Unauthorized(token);
            }

            return Ok("logaginho");
        }
    }
}
