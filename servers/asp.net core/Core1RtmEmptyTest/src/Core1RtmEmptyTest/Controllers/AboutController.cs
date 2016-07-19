using Microsoft.AspNetCore.Mvc;

namespace Core1RtmEmptyTest.Controllers
{
    [Route("[controller]")]
    public class AboutController : Controller
    {
        [Route("")]
        public ActionResult Hello()
        {
            return Content("Hello from DNT!");
        }
        [Route("[action]")]
        public ActionResult SiteName()
        {
            return Content("DNT");
        }

        [Route("Users/{userid:int?}", Name = "GetUserById")]
        public IActionResult GetUsers(int userId)
        {
            return Json(new {userId = userId});
        }
    }
}
