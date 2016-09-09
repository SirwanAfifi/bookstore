using Nancy;
using Nancy.Owin;
using Nancy.Security;

namespace Owin.Demo.Modules
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            // به جای اتریبیوت از این متد الحاقی استفاده می‌ کنیم.
            this.RequiresMSOwinAuthentication();

            Get["/nancy"] = x =>
            {
                var env = Context.GetOwinEnvironment();

                // از متد الحاقی زیر جهت دریافت کاربر جاری استفاده خواهیم کرد.
                var user = Context.GetMSOwinUser();

                return "Hello from Nancy! You requested: " + env["owin.RequestPathBase"] 
                + env["owin.RequestPath"] + "<br /><br />User: " + 
                user.Identity.Name;
            };
        }
    }
}