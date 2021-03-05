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
    public class SamStatsPageModel : PageModel
    {
        private readonly ILogger<SamStatsPageModel> _logger;
        private readonly IStatService statService;
        public SamStatResult SamStatResult = new SamStatResult();

        public SamStatsPageModel(IStatService statService, ILogger<SamStatsPageModel> logger)
        {
            _logger = logger;
            this.statService = statService;
        }
        public async Task OnGet()
        {
            SamStatResult = await statService.GetSamStatAsync();
            if (SamStatResult.br == null)
            {
                _logger.LogWarning(LoggingId.PrivateUsnPlatWarning, "The user you has their stats set to private");
            }
        }
    }
}