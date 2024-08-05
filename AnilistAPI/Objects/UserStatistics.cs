using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnilistAPI.Objects
{
    public class UserStatistics
    {
        public UserMediaStatistics? anime { get; set; }
        public UserMediaStatistics? manga { get; set; }
    }
}
