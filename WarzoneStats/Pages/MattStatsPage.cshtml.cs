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
    public class MattStatsPageModel : PageModel
    {
        private readonly ILogger<MattStatsPageModel> _logger;
        private readonly IStatService statService;
        public MattStatResult MattStatResult = new MattStatResult();

        public MattStatsPageModel(IStatService statService, ILogger<MattStatsPageModel> logger)
        {
            _logger = logger;
            this.statService = statService;
        }
        public async Task OnGet()
        {
            MattStatResult = await statService.GetMattStatAsync();
            if (MattStatResult.br == null)
            {
                _logger.LogWarning(LoggingId.PrivateUsnPlatWarning, "The user you has their stats set to private");
            }
        }
    }
}
