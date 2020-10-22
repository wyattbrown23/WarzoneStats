using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarzoneStats.Models;

namespace WarzoneStats.Data
{
    public interface IStatService
    {
        Task<WyattStatResult> GetWyattStatAsync();
        Task<AustinStatResult> GetAustinStatAsync();
        Task<MattStatResult> GetMattStatAsync();
        Task<SamStatResult> GetSamStatAsync();
        Task<SteveStatResult> GetSteveStatAsync();
        Task<UserStatResult> GetUserStatAsync(string userName, string platform);
    }
}
