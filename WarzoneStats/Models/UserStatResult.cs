using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarzoneStats.Models
{
    public class UserStatResult
    {
        public UserStatResult()
        {
            br = new UserWarzoneStatBR();
        }
        public UserWarzoneStatBR br { get; set; }
    }
}
