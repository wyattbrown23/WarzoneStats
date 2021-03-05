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
    public class AustinStatsPageModel : PageModel
    {
        private readonly ILogger<AustinStatsPageModel> _logger;
        private readonly IStatService statService;
        public AustinStatResult AustinStatResult = new AustinStatResult();

        public AustinStatsPageModel(IStatService statService, ILogger<AustinStatsPageModel> logger)
        {
            _logger = logger;
            this.statService = statService;
        }
        public async Task OnGet()
        {
            AustinStatResult = await statService.GetAustinStatAsync();
            if(AustinStatResult.br == null)
            {
                _logger.LogWarning(LoggingId.PrivateUsnPlatWarning, "The user you has their stats set to private");
            }
        }
    }
}
