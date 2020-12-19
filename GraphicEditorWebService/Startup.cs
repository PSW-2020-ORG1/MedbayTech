using Backend.Medications.Service;
using Backend.Rooms.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Service.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Medications.Repository.FileRepository;
using Backend.Medications.Repository.MySqlRepository;
using Repository.RoomRepository;
using Backend.Rooms.Repository.MySqlRepository;
using Backend.Users.Repository;
using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Backend.Schedules.Service.Interfaces;
using Backend.Schedules.Service;
using Backend.Schedules.Repository.MySqlRepository;
using Repository.ScheduleRepository;
using Backend.Users.Service.Interfaces;
using Backend.Users.Service;
using Repository.MedicalRecordRepository;
using Backend.Examinations.Service;
using Backend.Examinations.Service.Interfaces;
using Backend.Records.Repository.MySqlRepository;
using SimsProjekat.Service.RoomService;

namespace GraphicEditorWebService
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
            services.AddDbContext<MySqlContext>();
            services.AddTransient<IRoomRepository, RoomSqlRepository>();
            services.AddTransient<IHospitalEquipmentRepository, HospitalEquipmentSqlRepository>();
            services.AddTransient<IMedicationRepository, MedicationSqlRepository>();
            services.AddTransient<IDoctorRepository, DoctorSqlRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentSqlRepository>();
            services.AddTransient<IDoctorWorkDayRepository, DoctorWorkDaySqlRepository>();
            services.AddTransient<IPatientRepository,PatientSqlRepository>();
            services.AddTransient<IMedicalRecordRepository, MedicalRecordSqlRepository>();
            services.AddTransient<IEquipmentTypeRepository, EquipmentTypeSqlRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IHospitalEquipmentService, HospitalEquipmentService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
            services.AddScoped<IAppointmentFilterService, AppointmentFilterService>();
            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
    }
}
