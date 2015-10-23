using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using System.IO;

namespace InSeasonAPI.Utils
{
    class Converter
    {
        public object Convert()
        {
           // using (StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/crow.json")))
           // {
                var excel = new ExcelQueryFactory(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/crow.json"));
            //}
            return (from x in excel.Worksheet<object>() select x).FirstOrDefault();
        }
    }
}
