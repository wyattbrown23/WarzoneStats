using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WarzoneStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WyattStatsController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public WyattStatsController(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        [HttpGet("[action]")]
        public async Task<WyattStatResult> WyattStatsRaw()
        {
            var client = new HttpClient();
            var key = configuration["x-rapidapi-key"];
            var request = new HttpRequestMessage
            
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rapidapi.p.rapidapi.com/warzone/fadelessdaisy2/psn"),
                Headers =
                {
                    { "x-rapidapi-host", "call-of-duty-modern-warfare.p.rapidapi.com" },
                    { "x-rapidapi-key", key },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var statResult =  JsonSerializer.Deserialize<WyattStatResult>(body);
                return statResult;

            }

        }
    }
}
