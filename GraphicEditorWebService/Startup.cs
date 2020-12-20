using Backend.Medications.Service;
using Backend.Rooms.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using Service.RoomService;
using System;
using Backend.Medications.Repository.FileRepository;
using Backend.Medications.Repository.MySqlRepository;
using Repository.RoomRepository;
using Backend.Rooms.Repository.MySqlRepository;
using Backend.Users.Repository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Backend.Utils;
using SimsProjekat.Service.RoomService;
using Backend.Schedules.Service.Interfaces;
using Backend.Schedules.Service;
using Repository.ScheduleRepository;
using Backend.Schedules.Repository.MySqlRepository;
using Backend.Users.Service;
using Backend.Users.Service.Interfaces;
using Backend.Examinations.Service.Interfaces;
using Backend.Examinations.Service;
using Repository.MedicalRecordRepository;
using Backend.Records.Repository.MySqlRepository;

namespace GraphicEditorWebService
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

            AddRepository(services); 
            AddServices(services);
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors();
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
                        context.Database.Migrate();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to execute migration");
                }
                try
                {
                    DataSeeder seeder = new DataSeeder();
                    seeder.SeedAllEntities(context);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true));
        }


        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IHospitalEquipmentService, HospitalEquipmentService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentFilterService, AppointmentFilterService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddControllers();
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddTransient<IRoomRepository, RoomSqlRepository>();
            services.AddTransient<IHospitalEquipmentRepository, HospitalEquipmentSqlRepository>();
            services.AddTransient<IMedicationRepository, MedicationSqlRepository>();
            services.AddTransient<IDoctorRepository, DoctorSqlRepository>();
            services.AddTransient<IEquipmentTypeRepository, EquipmentTypeSqlRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentSqlRepository>();
            services.AddTransient<IDoctorWorkDayRepository, DoctorWorkDaySqlRepository>();
            services.AddTransient<ISurveyRepository, SurveySqlRepository>();
            services.AddTransient<IPatientRepository, PatientSqlRepository>();
            services.AddTransient<IMedicalRecordRepository, MedicalRecordSqlRepository>();
        }

    }
}
