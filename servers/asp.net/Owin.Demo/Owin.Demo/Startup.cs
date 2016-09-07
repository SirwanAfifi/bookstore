using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Nancy;
using Nancy.Owin;
using Owin;
using Owin.Demo.Middleware;

namespace Owin.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleware(new DebubMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine("Request took: " + watch.Elapsed.Milliseconds);
                }
            });

            var webApiconfig = new HttpConfiguration
            {
                
            };
            // این متد تمامی کنترلرها را جستجو کرده
            // و تمامی اتریبیوت‌هایی که نوشته‌ایم را نگاشت خواهد داد
            webApiconfig.MapHttpAttributeRoutes();
            // افزودن وب‌ای‌پی‌آی به پایپ‌لاین
            app.UseWebApi(webApiconfig);

            //app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
            app.UseNancy(config =>
            {
                config.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
            });

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Hello World</h1></body></html>");
            });
        }
    }
}
