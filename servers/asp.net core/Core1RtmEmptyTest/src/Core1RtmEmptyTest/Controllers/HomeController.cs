using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core1RtmEmptyTest.Controllers
{
    public class HomeController
    {
        [ActionContext]
        public ActionContext ActionContext { get; set; }

        public HttpContext HttpContext => ActionContext.HttpContext;

        public string Index()
        {
            return "Running a POCO controller!";
        }

        public IActionResult About()
        {
            return new ContentResult
            {
                Content = "Hello from DNT!",
                ContentType = "text/plain; charset=utf-8"
            };
        }
    }
}
