using System;
using System.IO;
using Backend.Examinations.Repository;
using Backend.Examinations.Repository.MySqlRepository;
using Backend.Examinations.Service.Interfaces;
using Backend.Examinations.WebApiService;
using Backend.Records.Repository.MySqlRepository;
using Backend.Records.WebApiService;
using Backend.Rooms.Service;
using Backend.Schedules.Repository.MySqlRepository;
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
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Backend.Utils;
using Microsoft.EntityFrameworkCore;
using IMedicalRecordService = Backend.Records.Service.Interfaces.IMedicalRecordService;

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

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });

            services.AddDbContext<MedbayTechDbContext>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<MedbayTechDbContext>())
            {
                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();

                try
                {
                    if (!stage.Equals("development") && IsPostgres())
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
                    DataSeeder seeder = new DataSeeder();
                    seeder.SeedAllEntities(context);

                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to seed data");
                }
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();


            if (stage.Equals("production"))
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dist"))
                });
            }
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

        public bool IsPostgres()
        {
            string host = Environment.GetEnvironmentVariable("DATABASE_TYPE") ?? "localhost";
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