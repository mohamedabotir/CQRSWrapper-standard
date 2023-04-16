using AspSample.Models;
using AspSample.Queries;
using Microsoft.AspNetCore.Mvc;
using Sample.Commands;
using Sample.Providers;

namespace AspSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private  readonly CQSScane _scane;

       
   

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CQSScane scane)
        {
            _logger = logger;
            _scane = scane;
        }

        [HttpGet]
        [Route("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var command = new UserCommand {  Id=1, Name = "Mohamed" };
            _scane.Dispatch(command);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55)
             })
            .ToArray();
        }
        [HttpGet]
        [Route("GetUserWithId")]
        public IActionResult GetUserWithId(int userId)
        {
            var query = new GetUserList(userId);
            return Ok(_scane.Dispatch(query));

        }

    }
}