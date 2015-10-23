using System.Collections.Generic;
using System.Web.Http;

namespace InSeasonAPI.Controllers
{
    public class RootController : ApiController
    {
        [Route("something")]
        public IHttpActionResult Get()
        {
            return this.Ok("WHUT");
        }
    }
}
