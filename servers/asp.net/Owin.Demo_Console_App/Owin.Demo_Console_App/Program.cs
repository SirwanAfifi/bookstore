using System;
using Microsoft.Owin.Hosting;

namespace Owin.Demo_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Server started");
                Console.ReadLine();
                Console.WriteLine("Server stopped!");
            }

        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            app.UseWelcomePage();
            app.Run(ctx =>
            {
                throw new Exception();
                return ctx.Response.WriteAsync("Hello");
            });
        }
    }
}
