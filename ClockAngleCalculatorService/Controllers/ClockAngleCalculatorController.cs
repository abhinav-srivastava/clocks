using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleService.Infrastructure.Exceptions;
using SampleService.Infrastructure.Repository;

namespace SampleService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClockAngleCalculatorController : ControllerBase
    {
        private readonly ILogger<ClockAngleCalculatorController> _logger;
        private readonly IClockCalculatorRepository _clockCalculatorRepository;
        public ClockAngleCalculatorController(ILogger<ClockAngleCalculatorController> logger, IClockCalculatorRepository repository)
        {
            _logger = logger;
            _clockCalculatorRepository = repository;
        }

        [HttpGet("{hour}/{min}")]
        [ProducesResponseType(typeof(double), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> Get(double hour, double min)
        {
            if (hour < 0 || min < 0 || hour > 12 || min > 60)
            {
                _logger.LogInformation("Invalid value of hour or min.");
                throw new ClockCalculatorException("Invalid value of hour or min");
            }

            var data = await  _clockCalculatorRepository.CalculateClockAngleAsync(hour, min).ConfigureAwait(false);
            return Ok(data);
        }
    }
}
