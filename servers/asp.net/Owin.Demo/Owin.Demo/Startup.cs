using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
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

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Auth/Login")
            });

            app.Use(async (ctx, next) =>
            {
                if (ctx.Authentication.User.Identity.IsAuthenticated)
                    Debug.WriteLine("User: " + ctx.Authentication.User.Identity.Name);
                else
                    Debug.WriteLine("User Not Authenticated");
                await next();
            });

            var webApiconfig = new HttpConfiguration
            {
                
            };
            // این متد تمامی کنترلرها را جستجو کرده
            // و تمامی اتریبیوت‌هایی که نوشته‌ایم را نگاشت خواهد داد
            webApiconfig.MapHttpAttributeRoutes();
            // افزودن وب‌ای‌پی‌آی به پایپ‌لاین
            app.UseWebApi(webApiconfig);

            app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
            /*app.UseNancy(config =>
            {
                config.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
            });*/

            // چون این میان افزار یک خروجی به ریسپانس ارسال می‌کند
            // در نتیجه درخواست‌ها جهت رسیدگی به فریم‌ورک ام‌وی‌سی ارسال نخواهد شد.
            // ام‌وی‌سی زمانی همراه با پروژه کاتانا کار خواهد کرد که هیچ میان افزاری درون پایپ‌لاین وجود نداشته باشد که
            // خروجی را به ریسپانس ارسال کند.
            /*app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Hello World</h1></body></html>");
            });*/
        }
    }
}
