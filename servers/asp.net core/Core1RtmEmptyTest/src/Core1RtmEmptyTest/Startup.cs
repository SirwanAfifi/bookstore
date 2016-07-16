using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Core1RtmEmptyTest.Services;
using Microsoft.Extensions.Configuration;
using StructureMap;
using Core1RtmEmptyTest.ViewModels;

namespace Core1RtmEmptyTest
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddInMemoryCollection(new[]
                {
                  new KeyValuePair<string, string>("the-key", "the-value"),
                })
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<SmtpConfig>(options => Configuration.GetSection("Smtp").Bind(options));

            services.AddDirectoryBrowser();

            var container = new Container();
            container.Configure(config =>
            {
                config.For<IConfigurationRoot>().Singleton().Use(() => Configuration);
                config.Scan(_ =>
                {
                    _.AssemblyContainingType<IMessagesService>();
                    _.WithDefaultConventions();
                });

                config.Populate(services);
            });

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IMessagesService messagesService)
        {
            /* app.UseDefaultFiles();

            app.UseStaticFiles(); // For the wwwroot folder

            // For the files outside of the wwwroot
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(root: Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFiles")),
                RequestPath = new PathString("/StaticFiles")
            });

            // For DirectoryBrowser
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(root: Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
                RequestPath = new PathString("/MyImages")
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(root: Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
                RequestPath = new PathString("/MyImages")
            });

            //app.UseWelcomePage(); 
            */

            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorHandlingPath: "/MyControllerName/SomeActionMethodName");
            }

            app.Run(async context =>
            {
                var siteName = messagesService.GetSiteName();
                await context.Response.WriteAsync($"Hello {siteName}");
            });
        }
    }
}
