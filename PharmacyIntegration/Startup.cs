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
using System;
using Npgsql;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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
            Directory.CreateDirectory("DrugSpecifications");
            // Generated directory for prescription
            Directory.CreateDirectory("GeneratedPrescription");

			services.AddCors();

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

            if (!IsPostgresDatabase() && !IsTestEnvironment())
            {
                services.AddDbContextPool<MySqlContext>(
                options => options.UseMySql(CreateConnectionStringFromEnvironment(),

                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql)
                        .EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    }
                ));
                services.AddDbContext<MySqlContext>(options =>
                    options.UseMySql(CreateConnectionStringFromEnvironment()));
            }
            else
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                services.AddDbContext<MySqlContext>(options => options.UseNpgsql(CreateConnectionStringFromEnvironment()));
            }
            services.AddScoped<MySqlContext>();



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
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    // Launch development server for Vue.js
                    spa.UseVueDevelopmentServer();
                }
            });

            if (!IsLocalServer() || IsPostgresDatabase() || IsTestEnvironment())
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<MySqlContext>();

                    RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                    if (!databaseCreator.HasTables())
                        databaseCreator.CreateTables();
                }
            }
        }

        public string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newdb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";


            string url = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "localhost";

            if (url.Equals("localhost") && !IsTestEnvironment())
                return $"server={server};port={port};database={database};user={user};password={password}";

            else if (IsTestEnvironment())
            {
                return Environment.GetEnvironmentVariable("CONNECTION_STRING");
            }

            else
            {
                var databaseUri = new Uri(url);
                var userInfo = databaseUri.UserInfo.Split(':');

                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = databaseUri.Host,
                    Port = databaseUri.Port,
                    Username = userInfo[0],
                    Password = userInfo[1],
                    Database = databaseUri.LocalPath.TrimStart('/')
                };
                return builder.ToString();
            }

        }
        public bool IsLocalServer()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return server.Equals("localhost");
        }

        public bool IsPostgresDatabase()
        {
            string url = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "localhost";
            return !url.Equals("localhost");
        }

        public bool IsTestEnvironment()
        {
            string environment = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "FALSE";
            return environment.Equals("TRUE");
        }
    }
}

