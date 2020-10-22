using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WarzoneStats.Data;

namespace WarzoneStats.Pages
{
    public class WyattStatsPageModel : PageModel
    {
        private readonly IStatService statService;
        public WyattStatResult WyattStatResult = new WyattStatResult();

        public WyattStatsPageModel(IStatService statService)
        {
            this.statService = statService;
        }
        public async Task OnGet()
        {
            WyattStatResult = await statService.GetWyattStatAsync();
        }
        
    }
}
