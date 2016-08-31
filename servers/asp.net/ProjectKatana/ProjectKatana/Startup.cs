using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectKatana.Startup))]
namespace ProjectKatana
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
