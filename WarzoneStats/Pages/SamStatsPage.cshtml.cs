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
    public class SamStatsPageModel : PageModel
    {
        private readonly IStatService statService;
        public SamStatResult SamStatResult = new SamStatResult();

        public SamStatsPageModel(IStatService statService)
        {
            this.statService = statService;
        }
        public async Task OnGet()
        {
            SamStatResult = await statService.GetSamStatAsync();
        }
    }
}