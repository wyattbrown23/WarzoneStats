using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WarzoneStats.Data;

namespace WarzoneStats.Pages
{
    public class AustinStatsPageModel : PageModel
    {
        private readonly IStatService statService;
        public AustinStatResult AustinStatResult = new AustinStatResult();

        public AustinStatsPageModel(IStatService statService)
        {
            this.statService = statService;
        }
        public async Task OnGet()
        {
            AustinStatResult = await statService.GetAustinStatAsync();
        }
    }
}
