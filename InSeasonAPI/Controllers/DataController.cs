using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InSeasonAPI.Models;
using Newtonsoft.Json;
using InSeasonAPI.Utils;

namespace InSeasonAPI.Controllers
{
    public class DataController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="date"></param>
        /// <param name="countyID"></param>
        /// <returns></returns>
        [Route("GetCounty/{animal}/{date}/{countyID}")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Get(string animal, string date, string countyID)
        {
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(string.Format("~/App_Data/animals/{0}.json", animal))))
            {
                Hunting animalobj = await System.Threading.Tasks.Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Hunting>(reader.ReadToEnd()));

                var conversion = new Utils.Converter();
                var ids = conversion.CountyToGnis(Convert.ToInt32(countyID)).Select(x => x.FEATURE_ID).ToList();

              //  var seasons = (from s in animalobj.seasons select s).ToList();
               
                List<ReturnInfo> returnData = new List<ReturnInfo>();
                foreach (var ranges in animalobj.seasons)
                {
                    var localRestrictions = new List<Location>();
                    foreach (var range in ranges.range)
                    {
                        if (range?.season?.date != null)
                        {
                            if (DateConverter.ConvertToDateTime(date) >=
                                DateConverter.ConvertToDateTime(range.season.date.starts) &&
                                DateConverter.ConvertToDateTime(date) <= DateConverter.ConvertToDateTime(range.season.date.ends)
                                )
                            {
                                var vals = range.places.Values;
                                localRestrictions.AddRange(vals.Select(val => new Location
                                {
                                    gnis_id = val.gnis_id,
                                    fips_code = val.fips_code,
                                    restriction = val.restriction
                                }).Where(
                                    x => ids.Contains(TypeConvert.StrToIntDef(x.gnis_id, 0)
                                 ))
                               );
                            }
                        }
                    }
                    returnData.Add(new ReturnInfo(ranges, localRestrictions));
                }
                return Ok(returnData);
            }
        }
    }
}
