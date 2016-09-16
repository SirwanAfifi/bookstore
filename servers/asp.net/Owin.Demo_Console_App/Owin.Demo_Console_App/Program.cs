using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Owin.Demo_Console_App
{
    using System.IO;
    using System.Web.Http;
    using AppFunc = Func<IDictionary<string, object>, Task>;


    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (environment, next) =>
            {
                Console.WriteLine("Requesting : " + environment.Request.Path);

                await next();

                Console.WriteLine("Response : " + environment.Response.StatusCode);
            });

            ConfigureWebApi(app);

            app.UseHelloWorldComponent();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new {controller = "Movie", action = "Get", id = RouteParameter.Optional});
            app.UseWebApi(config);
        }
    }

    public static class AppBuilderExtension
    {
        public static void UseHelloWorldComponent(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        private readonly AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!");
            }
        }
    }
}
