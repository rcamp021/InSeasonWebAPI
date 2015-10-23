using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InSeasonAPI.Models
{
    class GnisCountyDefinition
    {
        public int FEATURE_ID { get; set; }

        public int COUNTY_NUMERIC { get; set; }

        public string FEATURE_NAME { get; set; }

        public string COUNTY_NAME { get; set; }

        public string STATE_ALPHA { get; set; }

        public int STATE_NUMERIC { get; set; }
    }
}