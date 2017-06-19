using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Template
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            var defaultController = Wlniao.Config.GetEnvironment("Controller");
	        if (string.IsNullOrEmpty(defaultController))
	        {
	            defaultController = "home";
	        }
	        else
	        {
	            defaultController = defaultController.ToLower();
	        }
            app.UseStaticFiles();
            app.UseMvc();
            app.UseMvc(routes => //加载路由配置
            {
	            routes.MapRoute("Path", "{controller}/{action}", new { action = "index" });
	            routes.MapRoute("Home", "{action}", new { controller = defaultController });
	            routes.MapRoute("Root", "", new { controller = defaultController, action = "index" });
            });
        }
    }
}
