using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHHC.Core;
using BHHC.Core.Models;
using BHHC.DataAccessLayer;
using BHHC.ServiceLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BHHC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqLiteConnString = Configuration.GetConnectionString("sqlite");
            var pgSqlConnString = Configuration.GetConnectionString("pgsql");

            services.AddRazorPages();
            services.AddDbContext<ReasonContext>(options => options.UseSqlite(sqLiteConnString));
            //services.AddDbContext<ReasonContext>(options => options.UseNpgsql(pgSqlConnString));
            services.AddScoped<IReasonService, ReasonService>();
            services.AddScoped<IReasonAccessor, ReasonAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            CreateAndPopulateDb(app.ApplicationServices);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        // this is 'temporary' as I'm not sure how we're going to populate the db without this, or I guess we could use DBUp
        public void CreateAndPopulateDb(IServiceProvider serviceProvider)
        {

            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ReasonContext>();
                if (!context.Reasons.Any())
                {
                    context.AddRange(Constants.SeededReasons);
                    context.SaveChanges();
                }                
            }           
        }
    }
}
