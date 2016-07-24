using System.IO;
using System.Reflection;
using Core1RtmEmptyTest.Features.StartupCustomizations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Core1RtmEmptyTest
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureLocationExpander());

                var thisAssembly = typeof (Startup).GetTypeInfo().Assembly;
                options.FileProviders.Clear();
                options.FileProviders.Add(new EmbeddedFileProvider(thisAssembly, baseNamespace: "Core1RtmEmptyTest"));
            });
            //services.Configure<SmtpConfig>(options => Configuration.GetSection("Smtp").Bind(options));

            //services.AddDirectoryBrowser();

            //services.AddSingleton<IConfiguration>(provider => { return Configuration; });
            //services.AddTransient<IMessagesService, MessagesService>();

        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env)
        {

            // Serve wwwroot as root
            app.UseFileServer();

            // Serve /node_modules as a separate root (for packages that use other npm modules client side)
            app.UseFileServer(new FileServerOptions
            {
                // Set root of file server
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                // Only react to requests that match this path
                RequestPath = "/node_modules",
                // Don't expose file system
                EnableDirectoryBrowsing = false
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });
        }
    }
}
