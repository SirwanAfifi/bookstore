using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using StructureMap;

namespace Core1RtmEmptyTest
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

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
