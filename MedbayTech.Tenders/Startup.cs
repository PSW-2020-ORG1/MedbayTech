using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Tenders.Application.Common.Interfaces.Gateways;
using MedbayTech.Tenders.Application.Common.Interfaces.Persistance.Tenders;
using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Tenders.Infrastructure.Database;
using MedbayTech.Tenders.Infrastructure.Gateways;
using MedbayTech.Tenders.Infrastructure.Persistance.Tenders;
using MedbayTech.Tenders.Infrastructure.Service.Tenders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MedbayTech.Tenders
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            AddRepository(services);
            AddServices(services);
            services.AddControllers();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<TenderDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<TenderDbContext>())
            {
                string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
                string host = Environment.GetEnvironmentVariable("DATABASE_TYPE") ?? "localhost";

                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();

                try
                {
                    if (!stage.Equals("development") && host.Equals("postgres"))
                        databaseCreator.CreateTables();
                    else
                        context.Database.Migrate();
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to execute migration");
                }
                try
                {
                    TenderDataSeeder seeder = new TenderDataSeeder();
                    if (!seeder.IsAlreadyFull(context))
                        seeder.SeedAllEntities(context);

                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to seed data");
                }
            }
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }
        }


        private static void AddRepository(IServiceCollection services)
        {
            services.AddTransient<ITenderRepository, TenderSqlRepositroy>();
            services.AddTransient<ITenderMedicationRepositroy, TenderMedicationSqlRepositroy>();
            services.AddTransient<ITenderOfferRepository, TenderOfferSqlRepositroy>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<ITenderOfferService, TenderOfferService>();
            services.AddScoped<IPharmacyGateway, PharmacyGateway>();
        }
    }
}
