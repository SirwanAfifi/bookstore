using System.Net;
using System.Web.Http;

namespace Owin.Demo.Controllers
{
    [RoutePrefix("api")]
    public class HelloWorldApiController : ApiController
    {
        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(HttpStatusCode.OK, "Hello from Web Api");
        }
    }
}