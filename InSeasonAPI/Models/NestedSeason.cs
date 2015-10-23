using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSeasonAPI.Models
{
    class NestedSeason
    {
        public mydate date { get; set; }
        public List<string> days { get; set; }
    }
}
