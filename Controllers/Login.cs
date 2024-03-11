using Microsoft.AspNetCore.Mvc;

namespace Credentials.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Login : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public Login(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "")]
        public IActionResult Post()
        {

        var token = "df,.dsplg,dokmg";
            
            Response.Cookies.Append("session", token, new CookieOptions()
            {
                Path = "/",
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(4)
            });

            return Ok(token);
        }
    }
}