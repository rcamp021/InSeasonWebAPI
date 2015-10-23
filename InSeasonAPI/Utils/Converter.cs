using System.Collections.Generic;
using System.Linq;
using LinqToExcel;
using InSeasonAPI.Models;

namespace InSeasonAPI.Utils
{
    class Converter
    {
        private IExcelQueryFactory excelQueryFactory;

        public Converter ()
        {
            this.excelQueryFactory = new ExcelQueryFactory(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/GNIS-County-Definitions.csv"));
        }

        public GnisCountyDefinition GnisToCounty(int gnis)
        {
            return (from x in excelQueryFactory.Worksheet<GnisCountyDefinition>() where x.FEATURE_ID == gnis select x).FirstOrDefault();
        }

        public GnisCountyDefinition CountyToGnis(int county)
        {
            return (from x in excelQueryFactory.Worksheet<GnisCountyDefinition>() where x.COUNTY_NUMERIC == county select x).FirstOrDefault();
        }

    }
}
