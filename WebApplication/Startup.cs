using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
using Backend.Schedules.Repository.MySqlRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Backend.Schedules.Service.Interfaces;
using Model;
using Newtonsoft.Json;
using Repository.MedicalRecordRepository;
using Repository.ScheduleRepository;
using Service.ScheduleService;
using Repository.UserRepository;
using WebApplication.MailService;
using WebApplication.ObjectBuilder;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<MySqlContext>(options =>
                options.UseMySql(CreateConnectionStringFromEnvironment()));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "4200";

            app.UseCors(options => options.WithOrigins($"http://{origin}:{port}").AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                    RequestPath = "/Resources"
                });
            } else
            {/*
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "WebApplication", "Resources")),
                    RequestPath = "/Resources"
                });
            */}

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist"))
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MySqlContext>();
                
                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                if (!databaseCreator.HasTables())
                {
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
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


            return $"server={server};port={port};database={database};user={user};password={password}";
            // string url = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "localhost";
            /*
            if (url.Equals("localhost") && !IsTestEnvironment())

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
            }*/



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

