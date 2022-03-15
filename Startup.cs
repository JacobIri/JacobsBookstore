using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JacobsBookstore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace JacobsBookstore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //ADDED BY JACOB


        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public IConfiguration Configuration { get; }
        //


        public void ConfigureServices(IServiceCollection services)
        {
            //ADDED BY JACOB
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
               options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);

            });

            services.AddScoped<IJacobsBookstoreRepository, EFJacobsBookstoreRepository>();
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ADDED BY JACOB -Can use wwwroot
            app.UseStaticFiles();
            //

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //REMOVED THEN REPLACED BY JACOB
                endpoints.MapDefaultControllerRoute();
                //
            });
        }
    }
}
