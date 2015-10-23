using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSeasonAPI.Models
{
    class Hunting
    {
        public string agency { get; set; }
        public DateTime date_effective { get; set; }
        public DateTime date_expires { get; set; }
        public string documentation { get; set; }
        public string schema_version { get; set; }
        public string conformsTo { get; set; }
        public string state { get; set; }
        public Season seasons {get; set;}
        public Species species { get; set; }

    }
}
