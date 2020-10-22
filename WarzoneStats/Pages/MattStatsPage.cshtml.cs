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
    public class MattStatsPageModel : PageModel
    {
        private readonly IStatService statService;
        public MattStatResult MattStatResult = new MattStatResult();

        public MattStatsPageModel(IStatService statService)
        {
            this.statService = statService;
        }
        public async Task OnGet()
        {
            MattStatResult = await statService.GetMattStatAsync();
        }
    }
}
