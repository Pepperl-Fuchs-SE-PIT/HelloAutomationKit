using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloAutomationKit.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class WeatherForecastController : ControllerBase
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
        [Authorize(AutomationKitWebApiAppClaims.Read)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]

            })
            .ToArray();
        }
        [Authorize(AutomationKitWebApiAppClaims.Write)]
        [HttpPost(Name = "PostWeatherForecast")]
        public void Post(WeatherForecast weatherForecast)
        {

        }


        /*[HttpPost(Name = "SendTestFlagToMES")]
        public void SendTestFlagToMES(MesData mesData)
        {
            Trace.WriteLine(mesData.ToString());
            _logger.LogInformation("received MES Data {@MesData}", mesData);

        }*/
    }
}
