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
using Backend.Examinations.Repository;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.Service;
using Backend.Examinations.Service.Interfaces;
using Service.GeneralService;
using Backend.Records.Repository.MySqlRepository;
using Repository.MedicalRecordRepository;
using Repository.UserRepository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Medications.Service;
using Backend.Pharmacies.Repository.MySqlRepository;
using Backend.Reports.Repository;
using Backend.Reports.Repository.MySqlRepository;
using Backend.Reports.Service;
using Model;
using Backend.Utils;
using PharmacyIntegration.Repository;
using PharmacyIntegration.Service;
using Backend.Examinations.WebApiService;
using VueCliMiddleware;
using Backend.Pharmacies.Service;
using Backend.Pharmacies.Service.Interfaces;
using Backend.Medications.Repository.MySqlRepository;
using Backend.Medications.Repository.FileRepository;

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
            AddServices(services);
            AddRepository(services);

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSpaStaticFiles(options => options.RootPath = "vueclient/dist");

            services.AddDbContext<MedbayTechDbContext>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<MedbayTechDbContext>())
            {
                string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();

                try
                {
                    if (stage.Equals("test"))
                    {
                        databaseCreator.CreateTables();
                    }
                    else
                    {
                        context.Database.Migrate();
                    }
                } catch(Exception)
                {
                    Console.WriteLine("Failed to execute migration");
                }
                try
                {
                    DataSeeder seeder = new DataSeeder();
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
            services.AddTransient<IPharmacyRepository, PharmacySqlRepository>();
            services.AddTransient<IPharmacyNotificationRepository, PharmacyNotificationSqlRepository>();
            services.AddTransient<IMedicationUsageRepository, MedicationUsageSqlRepository>();
            services.AddTransient<IMedicationUsageReportRepository, MedicationUsageReportSqlRepository>();
            services.AddTransient<ITreatmentRepository, TreatmentSqlRepository>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IMedicalRecordRepository, MedicalRecordSqlRepository>();
            services.AddTransient<IUserRepository, UserSqlRepository>();
            services.AddTransient<INotificationRepository, NotificationSqlRepository>();
            services.AddTransient<IPrescriptionRepository, PrescriptionSqlRepository>();
            services.AddTransient<IUrgentMedicationProcurementRepository, UrgentMedicationProcurementSqlRepository>();
            services.AddTransient<IMedicationRepository, MedicationSqlRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IPharmacyNotificationService, PharmacyNotificationService>();
            services.AddScoped<IMedicationUsageService, MedicationUsageService>();
            services.AddScoped<IMedicationUsageReportService, MedicationUsageReportService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<IPrescriptionSearchService, PrescriptionSearchService>();
            services.AddScoped<IUrgentMedicationProcurementService, UrgentMedicationProcurementService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<INotificationService, NotificationService>();

        }


    }
}