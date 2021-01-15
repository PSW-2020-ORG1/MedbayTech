using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Medications;
using MedbayTech.Medications.Application.Common.Interfaces.Peristance.Reports;
using MedbayTech.Medications.Application.Common.Interfaces.Service;
using MedbayTech.Medications.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Medications.Infrastructure.Persistance;
using MedbayTech.Medications.Infrastructure.Persistance.Reports;
using MedbayTech.Medications.Infrastructure.Service.Medications;
using MedbayTech.Medications.Infrastructure.Service.Reports;
using MedbayTech.Medications.Infrastructure.Database;

namespace MedbayTech.Medication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        public void ConfigureServices(IServiceCollection services)
        {
            Directory.CreateDirectory("GeneratedUsageReports");
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            

            services.AddDbContext<MedicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<MedicationDbContext>())
            {
                string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
                string host = Environment.GetEnvironmentVariable("DATABASE_TYPE") ?? "localhost";

                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();

                try
                {
                    if (!stage.Equals("development") && host.Equals("postgres"))
                    {
                        databaseCreator.CreateTables();
                    }
                    else
                        context.Database.Migrate();
                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to execute migration");
                }
                try
                {
                    MedicationDataSeeder seeder = new MedicationDataSeeder();
                    if (!seeder.IsAlreadyFull(context))
                        seeder.SeedAllEntities(context);

                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to seed data");
                }
            }


            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseAuthorization();

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
            services.AddTransient<IMedicationUsageRepository, MedicationUsageRepository>();
            services.AddTransient<IMedicationUsageReportRepository, MedicationUsageReportRepository>();
            services.AddTransient<IMedicationRepository, MedicationRepository>();

        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IMedicationUsageService, MedicationUsageService>();
            services.AddScoped<IMedicationUsageReportService, MedicationUsageReportService>(); 
            services.AddScoped<IMedicationService, MedicationService>();
        }
    }
}
