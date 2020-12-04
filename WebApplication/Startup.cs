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
using Backend.Users.Repository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.Service;
using Backend.Users.Service.Interfaces;
using Backend.Users.TableBuilder.Interfaces;
using Backend.Users.WebApiService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Newtonsoft.Json;
using Repository.MedicalRecordRepository;
using Repository.UserRepository;
using WebApplication.MailService;
using WebApplication.ObjectBuilder;

namespace WebApplication
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
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;

            });

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService.MailService>();

            

            //add cors package
            services.AddCors();
            //services.RegisterMySQLDataServices(Configuration);
            services.AddDbContext<MySqlContext>();
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

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IPrescriptionSearchService, PrescriptionSearchService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
            services.AddScoped<IPatientTableBuilder, PatientTableBuilder>();
            services.AddScoped<IReportSearchService, ReportSearchService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<ISpecializationService, SpecializationService>();

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

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

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = "/Resources"
            });
        }
    }
}
