using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using InSeasonAPI.Models;
using System.Web;
using System.Web.Http.Cors;

namespace InSeasonAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RootController : ApiController
    {
        /// <summary>
        /// Get a county from a county code
        /// </summary>
        /// <param name="county">the county id to convert to a gnis id</param>
        /// <returns>The county</returns>
        [Route("getCountyLocation/{county}")]
        public IHttpActionResult CountyToGnis(string county)
        {
            var data = new Utils.Converter().CountyToGnis(Int32.Parse(county));

            return Ok(data);
        }

        /// <summary>
        /// Get a county from a gnis identifier
        /// </summary>
        /// <param name="gnis">The gnis id to convert to a county id</param>
        /// <returns>The county</returns>
        [Route("getGnisLocation/{gnis}")]
        public IHttpActionResult GnisToCounty(string gnis)
        {
            var data = new Utils.Converter().GnisToCounty(Int32.Parse(gnis));

            return Ok(data);
        }

        /// <summary>
        /// Get a list of all the animals
        /// </summary>
        /// <returns>Array of animals</returns>
        [Route("animals")]
        public IHttpActionResult GetAnimals()
        {
            var filenames = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/animals/"), "*.json")
                                     .Select(path => Path.GetFileNameWithoutExtension(path))
                                     .ToArray();

            var animals = new List<Animal>();
            foreach (var filename in filenames)
            {
                animals.Add(new Animal
                {
                    key = filename,
                    human = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filename).Replace('_', ' ')
                });
            }

            return Ok(animals);
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
