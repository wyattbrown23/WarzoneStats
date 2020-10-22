using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarzoneStats.Data
{
    public interface IStatService
    {
        Task<WyattStatResult> GetWyattStatAsync();
    }
}
