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
        public async System.Threading.Tasks.Task<IHttpActionResult> Get(string animal, DateTime date, string countyID)
        {
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(string.Format("~/App_Data/animals/{0}.json", animal))))
            {
                Hunting animalobj= await System.Threading.Tasks.Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Hunting>(reader.ReadToEnd()));
                var seasons = animalobj.seasons.Select(x => x.range.Where(y => DateConverter.ConvertToDateTime(y.season.date.starts) >= date && DateConverter.ConvertToDateTime(y.season.date.ends) <= date)).FirstOrDefault();

                var conversion = new Utils.Converter();
                var id = conversion.CountyToGnis(Convert.ToInt32(countyID));

                var counties = seasons.Select(x => x.places.Where(y => y.Key == id.ForEach(z)));
                return null;
            }
        }
    }
}
