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
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;
        private readonly IStatService statService;
        public UserStatResult UserStatResult = new UserStatResult();

        public HomeModel(IStatService statService, ILogger<HomeModel> logger)
        {
            _logger = logger;
            this.statService = statService;
        }

        public void OnGet()
        {
            //_logger.LogError("The server went down temporarily at {Time}", DateTime.UtcNow);
            //_logger.LogTrace("This is a trace log");
            //_logger.LogDebug("This is a debug log");
            //_logger.LogInformation(LoggingId.DemoCode, "This is an information log");
            //_logger.LogWarning("This is a warning log");
            //_logger.LogError("This is an error log");
            //_logger.LogCritical("this is a critical log");
        }
        
        public async Task OnPostGetUserStatAsync(string userName, string platform)
        {
            UserStatResult = await statService.GetUserStatAsync(userName, platform);
            if (UserStatResult.br.score == 0)
            {
                _logger.LogWarning(LoggingId.PrivateUsnPlatWarning,"The user you searched may not exist or their stats may be private");
            }
        }
    }
}
