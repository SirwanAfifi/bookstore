using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Owin.Demo_Console_App.Models;

namespace Owin.Demo_Console_App.Controllers
{
    public class MovieController : ApiController
    {
        public IHttpActionResult Get()
        {
            var data = new List<Movie>
            {
                new Movie {Title = "Prisoner", Genre = Genre.Crime, Rating = 8},
                new Movie {Title = "Felon", Genre = Genre.Crime, Rating = 8},
                new Movie {Title = "Felony", Genre = Genre.Crime, Rating = 8},
                new Movie {Title = "NightCrawler", Genre = Genre.Crime, Rating = 8},
            };
            return Json(data);
        } 
    }
}