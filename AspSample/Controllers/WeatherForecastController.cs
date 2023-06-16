using AspSample.Queries;
using Microsoft.AspNetCore.Mvc;
using CQRS;
using CQRS.Providers;
using Sample.Commands;
using AspSample.Commands;

namespace AspSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CQSScane _scane;




        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CQSScane scane)
        {
            _logger = logger;
            _scane = scane;
        }

        [HttpPost]
        [Route(nameof(AddUser))]
        public IActionResult AddUser(int id, string name)
        {
            var command = new UserCommand { Id = id, Name = name };
            _scane.Dispatch(command);
            return Ok();
        }
        [HttpGet]
        [Route("GetUserWithId")]
        public IActionResult GetUserWithId(int userId)
        {
            var query = new GetUserList(userId);
            return Ok(_scane.Dispatch(query));

        }

        [HttpGet]
        [Route(nameof(SetUserJobTestRetries))]
        public IActionResult SetUserJobTestRetries(int jobId,string jobName,bool isFaild)
        {
            var command = new JobIdCommand() { JobId = jobId, JobName = jobName,IsFail = isFaild };
            _scane.Dispatch(command);
            return Ok();

        }

    }
}