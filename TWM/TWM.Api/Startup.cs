using System;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TWM.Data;

namespace TWM.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //   {
            //       options.Authority = "https://localhost:44381";
            //       options.ApiName = "tripwithmeapi";
            //   });

            services.AddDbContext<TripWMeContext>(cfg =>
            {
                if (Environment.IsDevelopment())
                {
                    cfg.UseSqlServer(Configuration.GetConnectionString("ProductRoadMapConnectionString"));
                }
                else
                {
                    cfg.UseSqlServer(Configuration.GetConnectionString("ProductRoadMapConnectionStringProd"));
                }
            });

            services.AddTransient<TripWMeSeeder>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            if (env.IsDevelopment())
            {
                // Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var recreateDbOption = Configuration.GetSection("DevelopmentEnvironmentSettings").GetSection("RecreateDatabaseEachTime").Value;
                    var seeder = scope.ServiceProvider.GetService<TripWMeSeeder>();
                    seeder.Seed(recreateDbOption).Wait();
                }
            }
        }
    }
}
