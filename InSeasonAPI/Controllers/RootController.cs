using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using Newtonsoft.Json;
using InSeasonAPI.Models;
using System.Web;

namespace InSeasonAPI.Controllers
{
    public class RootController : ApiController
    {
        [Route("something")]
        public IHttpActionResult Get()
        {
            return this.Ok("WHUT");
        }

        /// <summary>
        /// Get a county from a county code
        /// </summary>
        /// <param name="county"></param>
        /// <returns></returns>
        [Route("getCountyLocation/{county}")]
        public IHttpActionResult CountyToGnis(string county)
        {
            var data = new Utils.Converter().CountyToGnis(Int32.Parse(county));

            return this.Ok(data);
        }

        /// <summary>
        /// Get a county from a gnis identifier
        /// </summary>
        /// <param name="gnis"></param>
        /// <returns></returns>
        [Route("getGnisLocation/{gnis}")]
        public IHttpActionResult GnisToCounty(string gnis)
        {
            var data = new Utils.Converter().GnisToCounty(Int32.Parse(gnis));

            return this.Ok(data);
        }

        private Hunting getdata()
        {
            using (StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/crow.json")))
            {
                return JsonConvert.DeserializeObject<Hunting>(sr.ReadToEnd());
            }

        }
    }
}
