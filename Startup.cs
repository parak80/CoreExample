using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreExample.Data;
using CoreExample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoreExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<CoreContext>();
			//addtransient has no data on themselves often just methods that do things - 
			//AddScoped is used for more expensive things to create, they kept around for 
			//the length of the connection, they can be kept in different scopes, 
			//the default is the one that has the length of what client request. 
			//AddSingleton use for services that created once and they are captured 
			//the life-time of service being up.down one
			services.AddTransient<IMailService, NullMailService>();
			//Support for real mail service

			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else {
				app.UseExceptionHandler("/error");
			}

				app.UseStaticFiles();
			app.UseMvc(cfg => 
			{
				cfg.MapRoute("Default", 
					"/{controller}/{action}/{id?}", 
					new { controller = "App", Action = "Index" }); //home
			});
		}
    }
}
