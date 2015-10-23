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

        [Route("test")]
        public string GetTest()
        {
            return getdata().ToString();
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
