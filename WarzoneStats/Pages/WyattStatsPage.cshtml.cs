using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WarzoneStats.Data;

namespace WarzoneStats.Pages
{
    public class WyattStatsPageModel : PageModel
    {
        private readonly ILogger<WyattStatsPageModel> _logger;
        private readonly IStatService statService;
        public WyattStatResult WyattStatResult = new WyattStatResult();

        public WyattStatsPageModel(IStatService statService, ILogger<WyattStatsPageModel> logger)
        {
            _logger = logger;
            this.statService = statService;
        }
        public async Task OnGet()
        {
            WyattStatResult = await statService.GetWyattStatAsync();
            if (WyattStatResult.br == null)
            {
                _logger.LogWarning(LoggingId.PrivateUsnPlatWarning, "The user you has their stats set to private");
            }
        }
        
    }
}
