using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WarzoneStats.Models;

namespace WarzoneStats.Data
{
    public class StatService : IStatService
    {
        private readonly ILogger<StatService> _logger;
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public StatService(HttpClient httpClient, IConfiguration configuration, ILogger<StatService> logger)
        {
            _logger = logger;
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<AustinStatResult> GetAustinStatAsync()
        {
            var client = new HttpClient();
            var key = configuration["x-rapidapi-key"];
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rapidapi.p.rapidapi.com/warzone/killcam_death/psn"),
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
                var statResult = JsonSerializer.Deserialize<AustinStatResult>(body);
                if(response.StatusCode.Equals(404))
                {
                    _logger.LogError("The API is DOWN");
                }
                if (statResult.Equals(null))
                {
                    _logger.LogError("The user's data may be private");
                }
                return statResult;

            }
        }

        public async Task<MattStatResult> GetMattStatAsync()
        {
            var client = new HttpClient();
            var key = configuration["x-rapidapi-key"];
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rapidapi.p.rapidapi.com/warzone/ground_pounder54/psn"),
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
                var statResult = JsonSerializer.Deserialize<MattStatResult>(body);
                return statResult;

            }
        }

        public async Task<SamStatResult> GetSamStatAsync()
        {
            var client = new HttpClient();
            var key = configuration["x-rapidapi-key"];
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rapidapi.p.rapidapi.com/warzone/classywinks/xbl"),
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
                var statResult = JsonSerializer.Deserialize<SamStatResult>(body);
                return statResult;

            }
        }

        public async Task<SteveStatResult> GetSteveStatAsync()
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
                var statResult = JsonSerializer.Deserialize<SteveStatResult>(body);
                return statResult;

            }
        }

        public async Task<UserStatResult> GetUserStatAsync(string userName, string platform)
        {
            var client = new HttpClient();
            var key = configuration["x-rapidapi-key"];
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://rapidapi.p.rapidapi.com/warzone/{userName}/{platform}"),
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
                var statResult = JsonSerializer.Deserialize<UserStatResult>(body);
                return statResult;

            }
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
