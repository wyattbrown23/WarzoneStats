using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WarzoneStats.Data
{
    public class StatService : IStatService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public StatService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }
        public async Task<WyattStatResult> GetWyattStatAsync()
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
                var statResult = JsonSerializer.Deserialize<WyattStatResult>(body);
                return statResult;

            }
        }
    }
}
