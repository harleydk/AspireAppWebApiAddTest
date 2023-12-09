using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aspire1.WeatherStatisticsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherStatisticsController(ILogger<WeatherStatisticsController> logger) : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] string value)
        {
            logger.LogInformation($"Called {nameof(Post)} on {nameof(WeatherStatisticsController)}");
            return;
        }

        [HttpGet]
        public string Get()
        {
            logger.LogInformation($"Called {nameof(Get)} on {nameof(WeatherStatisticsController)}");
            return string.Empty;
        }
    }
}
