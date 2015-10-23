using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSeasonAPI.Models
{
    
    class Season
    {
        public string name { get; set; }
        public List<string> method_rules { get; set; }
        public List<string> method { get; set; }
        public List<Range> range { get; set; }
    }
}
