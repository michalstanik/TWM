using System;
using System.Linq;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TWM.Api.Services;
using TWM.CoreHelpers.Interfaces;
using TWM.Data;
using TWM.Data.Repository;
using TWM.Data.RepositoryInterfaces;

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
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;

                var jsonOutputFormatter = setupAction.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();
                if (jsonOutputFormatter != null)
                {
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.tripwme.tripwithstats+json");


                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.tripwme.continents+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.tripwme.continentswithregions+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.tripwme.continentswithregionsandcountries+json");

                }
                var jsonInputFormatter = setupAction.InputFormatters.OfType<JsonInputFormatter>().FirstOrDefault();
                if (jsonInputFormatter != null)
                {

                }
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsHeadersAndMethods",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

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

            services.AddAutoMapper(typeof(Startup));

            // register the repository
            services.AddTransient<TripWMeSeeder>();
            services.AddTransient<TripWMeStatsSeeder>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IGeoEntitiesRepository, GeoEntitiesRepository>();
            services.AddScoped<IGeoAdminRepository, GeoAdminRepository>();
            services.AddScoped<IUserInfoService, UserInfoService>();

            // register an IHttpContextAccessor so we can access the current HttpContext in services by injecting it
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();        

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:8001";
                    options.ApiName = "tripwithmeapi";
                });
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

                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            // Enable CORS
            app.UseCors("AllowAllOriginsHeadersAndMethods");
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

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var statsSeeder = scope.ServiceProvider.GetService<TripWMeStatsSeeder>();

                statsSeeder.SeedRegionStats().Wait();

                statsSeeder.SeedContinentStats().Wait();
            }
        }
    }
}
