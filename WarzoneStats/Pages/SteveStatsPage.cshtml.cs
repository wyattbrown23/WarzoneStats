using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WarzoneStats.Data;
using WarzoneStats.Models;

namespace WarzoneStats.Pages
{
    public class SteveStatsPageModel : PageModel
    {
        private readonly IStatService statService;
        public SteveStatResult SteveStatResult = new SteveStatResult();

        public SteveStatsPageModel(IStatService statService)
        {
            this.statService = statService;
        }
        public async Task OnGet()
        {
            SteveStatResult = await statService.GetSteveStatAsync();
        }
    }
}
