using Microsoft.AspNetCore.Mvc;
using Pin.Spoticlone.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int totalItems)
        {
            var statistics = await _statisticsService.GetStatisticsAsync(totalItems);
            return Ok(statistics);
        }
    }
}
