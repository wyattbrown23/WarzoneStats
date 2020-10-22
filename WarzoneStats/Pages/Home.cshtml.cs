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
    public class HomeModel : PageModel
    {
        private readonly IStatService statService;
        public UserStatResult UserStatResult = new UserStatResult();

        public HomeModel(IStatService statService)
        {
            this.statService = statService;
        }

        public void OnGet()
        {
            UserStatResult.br.wins = 0;
            UserStatResult.br.kills = 0;
            UserStatResult.br.kdRatio = 0;
            UserStatResult.br.downs = 0;
            UserStatResult.br.topTen = 0;
            UserStatResult.br.contracts = 0;
            UserStatResult.br.revives = 0;
            UserStatResult.br.score = 0;
            UserStatResult.br.deaths = 0;
        }

        public async Task OnPostGetUserStatAsync(string userName, string platform)
        {
            UserStatResult = await statService.GetUserStatAsync(userName, platform);
        }
    }
}
