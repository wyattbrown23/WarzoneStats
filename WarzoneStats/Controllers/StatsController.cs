using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WarzoneStats.Data;
using WarzoneStats.Models;

namespace WarzoneStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatService statService;

        public StatsController(IStatService statService)
        {
            this.statService = statService;
        }

        [HttpGet("[action]")]
        public async Task<WyattStatResult> WyattStatsRaw()
        {
            return await statService.GetWyattStatAsync();
        }

        [HttpGet("[action]")]
        public async Task<AustinStatResult> AustinStatsRaw()
        {
            return await statService.GetAustinStatAsync();
        }

        [HttpGet("[action]")]
        public async Task<MattStatResult> MattStatsRaw()
        {
            return await statService.GetMattStatAsync();
        }

        [HttpGet("[action]")]
        public async Task<SamStatResult> SamStatsRaw()
        {
            return await statService.GetSamStatAsync();
        }

        [HttpGet("[action]")]
        public async Task<SteveStatResult> SteveStatsRaw()
        {
            return await statService.GetSteveStatAsync();
        }

        [HttpGet("[action]")]
        public async Task<SteveStatResult> SteveStatsRaw(string userName, string platform)
        {
            return await statService.GetSteveStatAsync();
        }
    }
}
