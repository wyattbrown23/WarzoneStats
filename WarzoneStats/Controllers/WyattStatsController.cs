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

namespace WarzoneStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WyattStatsController : ControllerBase
    {
        private readonly IStatService statService;

        public WyattStatsController(IStatService statService)
        {
            this.statService = statService;
        }

        [HttpGet("[action]")]
        public async Task<WyattStatResult> WyattStatsRaw()
        {
            return await statService.GetWyattStatAsync();
        }
    }
}
