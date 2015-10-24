using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InSeasonAPI.Models;
using Newtonsoft.Json;

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

               // string[] splitdate = date.Split('-');

             //   string newdate = splitdate[]

                var dates = animalobj.seasons.Select(x => x.range.Where(y => Convert.ToDateTime(y.season.date.starts) >= date && Convert.ToDateTime(y.season.date.ends) <= date));
                return null;
            }
        }
    }
}
