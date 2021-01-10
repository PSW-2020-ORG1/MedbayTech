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
using PharmacyIntegration.Service;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance;
using MedbayTech.Pharmacies.Infrastructure.Persistance;
using MedbayTech.Pharmacies.Infrastructure.Database;
using MedbayTech.Pharmacies.Infrastructure.Persistance.Reports;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Reports;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Persistance.Medications;
using MedbayTech.Pharmacies.Infrastructure.Persistance.Medications;
using MedbayTech.Pharmacies.Infrastructure.Service.Reports;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Reports;
using MedbayTech.Pharmacies.Infrastructure.Service.Medications;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Medications;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Infrastructure.Gateways;

namespace PharmacyIntegration
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
            Directory.CreateDirectory("DrugSpecifications");
            Directory.CreateDirectory("GeneratedPrescription");

            services.AddCors();
            AddRepository(services);
            AddServices(services);

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSpaStaticFiles(options => options.RootPath = "vueclient/dist");

            services.AddDbContext<PharmacyDbContext>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<PharmacyDbContext>())
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
                } catch(Exception)
                {
                    Console.WriteLine("Failed to execute migration");
                }
                try
                {
                    PharmacyDataSeeder seeder = new PharmacyDataSeeder();
                    if (!seeder.IsAlreadyFull(context))
                        seeder.SeedAllEntities(context);

                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to seed data");
                }
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)); 


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "vueclient";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8082");
                }
            });

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddTransient<IPharmacyRepository, PharmacyRepository>();
            services.AddTransient<IPharmacyNotificationRepository, PharmacyNotificationRepository>();
            services.AddTransient<IMedicationUsageRepository, MedicationUsageSqlRepository>();
            services.AddTransient<IMedicationUsageReportRepository, MedicationUsageReportSqlRepository>();
            services.AddTransient<IMedicationRepository, MedicationSqlRepository>(); 
            
            services.AddTransient<IMedicationRepository, MedicationSqlRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IPharmacyNotificationService, PharmacyNotificationService>();
            services.AddScoped<IMedicationUsageService, MedicationUsageService>();
            services.AddScoped<IMedicationUsageReportService, MedicationUsageReportService>();;
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IPrescriptionSearchService, PrescriptionSearchService>();
            services.AddScoped<IPrescriptionGateway, PrescriptionGateway>();

        }


    }
}