using Owin.Demo.Middleware;

namespace Owin
{
    public static class DebugMiddlewareExtensions
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebubMiddlewareOptions options = null)
        {
            if (options == null)
                options = new DebubMiddlewareOptions();

            app.Use<DebugMiddleware>(options);
        }
    }
}