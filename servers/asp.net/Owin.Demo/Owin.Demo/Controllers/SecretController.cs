using System.Web.Mvc;

namespace Owin.Demo.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}