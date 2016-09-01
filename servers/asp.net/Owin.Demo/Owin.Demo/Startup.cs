using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace Owin.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Hello World</h1></body></html>");
            });
        }
    }
}
