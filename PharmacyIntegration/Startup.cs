using Backend.Examinations.Repository;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.Service;
using Backend.Examinations.Service.Interfaces;
using Service.GeneralService;
using Backend.Records.Repository.MySqlRepository;
using Repository.MedicalRecordRepository;
using Repository.UserRepository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Medications.Repository.FileRepository;
using Backend.Medications.Repository.MySqlRepository;
using Backend.Medications.Service;
using Backend.Pharmacies.Repository.MySqlRepository;
using Backend.Reports.Repository;
using Backend.Reports.Repository.MySqlRepository;
using Backend.Reports.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using PharmacyIntegration.Repository;
using PharmacyIntegration.Service;
using Backend.Examinations.WebApiService;
using System.IO;

namespace PharmacyIntegration
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
            // NOTE(Jovan): Init directory for usage reports
            Directory.CreateDirectory("GeneratedUsageReports");

            services.AddDbContext<MySqlContext>();

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

            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IPharmacyNotificationService, PharmacyNotificationService>();
            services.AddScoped<IMedicationUsageService, MedicationUsageService>();
            services.AddScoped<IMedicationUsageReportService, MedicationUsageReportService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<IPrescriptionSearchService, PrescriptionSearchService>();

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSpaStaticFiles(options => options.RootPath = "vueclient/dist");

            // NOTE(Jovan): Does not work
            /*services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });*/


            services.AddCors();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // add following statements
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
                if (env.IsDevelopment())
                {
                    // Launch development server for Vue.js
                    spa.UseVueDevelopmentServer();
                }
            });
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)); // allow any origin
        }
    }
}
