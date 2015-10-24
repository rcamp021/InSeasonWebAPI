using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSeasonAPI.Models
{
    class ReturnInfo
    {
       // private Season ranges;

       public ReturnInfo(Season season, List<Location> locs)
        {
            Season = season;
            season.range = null;
            LocalRestrictions = locs;
        }

        //  public bool IsAllowed { get; set; }
        //  public List<string> CountyRestrictions { get; set; }
        //  public List<string> StateRestrictions { get; set; }
        public Season Season { get; set; }
        public List<Location> LocalRestrictions { get; set;}
    }
}
