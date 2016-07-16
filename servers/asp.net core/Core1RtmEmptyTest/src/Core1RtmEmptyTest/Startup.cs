using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using StructureMap;

namespace Core1RtmEmptyTest
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.Configure<SmtpConfig>(options => Configuration.GetSection("Smtp").Bind(options));

            services.AddDirectoryBrowser();

            //services.AddSingleton<IConfiguration>(provider => { return Configuration; });
            //services.AddTransient<IMessagesService, MessagesService>();
            
        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env)
        {

            app.UseFileServer();
            app.UseMvcWithDefaultRoute();
        }
    }
}
