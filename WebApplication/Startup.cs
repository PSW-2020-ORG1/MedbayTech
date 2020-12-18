using System;
using System.IO;
using Backend.Examinations.Repository;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.Service.Interfaces;
using Backend.Examinations.WebApiService;
using Backend.Records.Repository.MySqlRepository;
using Backend.Records.Service.Interfaces;
using Backend.Records.WebApiService;
using Backend.Rooms.Service;
using Backend.Schedules.Repository.MySqlRepository;
using Backend.Schedules.Service;
using Backend.Users.Repository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.Service;
using Backend.Users.Service.Interfaces;
using Backend.Users.TableBuilder.Interfaces;
using Backend.Users.WebApiService;
using Backend.Schedules.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Model;
using Newtonsoft.Json;
using Repository.MedicalRecordRepository;
using Repository.ScheduleRepository;
using Repository.UserRepository;
using WebApplication.MailService;
using WebApplication.ObjectBuilder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Backend.Utils;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication
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
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;

            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService.MailService>();

            services.AddCors();

            AddRepository(services);
            AddServices(services);

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });


            if (IsPostgres())
            {
                services.AddDbContext<MedbayTechDbContext>(options =>
                    options.UseNpgsql(CreateConnectionStringFromEnvironmentPostgres(),
                    x => x.MigrationsAssembly("Backend").EnableRetryOnFailure(
                            5, new TimeSpan(0, 0, 0, 10), new List<string>())
                        ).UseLazyLoadingProxies());
            }
            else
            {
                services.AddDbContext<MedbayTechDbContext>(options =>
                    options.UseMySql(CreateConnectionStringFromEnvironment(),
                    x => x.MigrationsAssembly("Backend").EnableRetryOnFailure(
                            5, new TimeSpan(0, 0, 0, 10), new List<int>())
                        ).UseLazyLoadingProxies());
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins(GetDomain()).AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<MedbayTechDbContext>())
            {
                string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                
                if (stage.Equals("testing") || stage.Equals("production"))
                {
                    databaseCreator.CreateTables();
                }
                
                try
                {
                    DataSeeder seeder = new DataSeeder();
                    seeder.SeedAllEntities(context);
                } catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist"))
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = "/Resources"
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "4200";

            return $"http://{origin}:{port}";
        }
        public string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newdb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"server={server};port={port};database={database};user={user};password={password}";
        }

        public string CreateConnectionStringFromEnvironmentPostgres()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newdb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string testEnvironment = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "FALSE";

            if (testEnvironment.Equals("TRUE"))
                return "Server=postgres;Port=5432;Database=mydb1;User Id=root;Password=root";

            return $"Server={server};Port={port};Database={database};User Id={user};Password={password}";
        }

        public bool IsPostgres()
        {
            string host = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return host.Equals("postgres");
        }
        
        
        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IPrescriptionSearchService, PrescriptionSearchService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientTableBuilder, PatientTableBuilder>();
            services.AddScoped<IReportSearchService, ReportSearchService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddScoped<IDoctorWorkDayService, DoctorWorkDayService>();
            services.AddScoped<IAppointmentService, Backend.Schedules.Service.AppointmentService>();
            services.AddScoped<ISpecializationService, SpecializationService>();
        }

        private void AddRepository(IServiceCollection services)
        {
            services.AddTransient<IDoctorRepository, DoctorSqlRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackSqlRepository>();
            services.AddTransient<IMedicalRecordRepository, MedicalRecordSqlRepository>();
            services.AddTransient<IPrescriptionRepository, PrescriptionSqlRepository>();
            services.AddTransient<IAddressRepository, AddressSqlRepository>();
            services.AddTransient<ICityRepository, CitySqlRepository>();
            services.AddTransient<IStateRepository, StateSqlRepository>();
            services.AddTransient<IInsurancePolicyRepository, InsurancePolicySqlRepository>();
            services.AddTransient<IPatientRepository, PatientSqlRepository>();
            services.AddTransient<IExaminationSurgeryRepository, ExaminationSurgerySqlRepository>();
            services.AddTransient<ISurveyRepository, SurveySqlRepository>();
            services.AddTransient<ISurveyQuestionRepository, SurveyQuestionSqlRepository>();
            services.AddTransient<ISpecializationRepository, SpecializationSqlRepository>();
            services.AddTransient<IDoctorWorkDayRepository, DoctorWorkDaySqlRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentSqlRepository>();
            services.AddTransient<ISpecializationRepository, SpecializationSqlRepository>();
        }
    }
}

