using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WarzoneStats.Data;
using WarzoneStats.Models;

namespace WarzoneStats.Pages
{
    public class SteveStatsPageModel : PageModel
    {
        private readonly ILogger<SteveStatsPageModel> _logger;
        private readonly IStatService statService;
        public SteveStatResult SteveStatResult = new SteveStatResult();

        public SteveStatsPageModel(IStatService statService, ILogger<SteveStatsPageModel> logger)
        {
            _logger = logger;
            this.statService = statService;
        }
        public async Task OnGet()
        {
            SteveStatResult = await statService.GetSteveStatAsync();
            if (SteveStatResult.br == null)
            {
                _logger.LogWarning(LoggingId.PrivateUsnPlatWarning, "The user you has their stats set to private");
            }
        }
    }
}
