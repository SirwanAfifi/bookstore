using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AngleSharp;
using AngleSharp.Extensions;
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

        [HttpGet]
        public async Task<IHttpActionResult> ShowAll()
        {
            var config = AngleSharp.Configuration.Default.WithDefaultLoader();
            var address = "https://www.rottentomatoes.com/top/bestofrt";
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var selector = "td .articleLink";
            var cells = document.QuerySelectorAll(selector);
            var movies = cells.Select(m => new Movie
            {
                Title = m.TextContent,
                RottenTomatoesRating = m.Parent.ParentElement.QuerySelector("td:nth-child(2) > span span:nth-child(2)").TextContent,
                Genre = Genre.Other
            });

            return Json(movies);
        } 
    }
}