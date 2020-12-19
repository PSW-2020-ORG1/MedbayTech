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
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Backend.Utils;

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
            services.AddTransient<IRoomRepository, RoomSqlRepository>();
            services.AddTransient<IHospitalEquipmentRepository, HospitalEquipmentSqlRepository>();
            services.AddTransient<IMedicationRepository, MedicationSqlRepository>();
            services.AddTransient<IDoctorRepository, DoctorSqlRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IHospitalEquipmentService, HospitalEquipmentService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddControllers();
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


        public string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newdb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"server={server};port={port};database={database};user={user};password={password}";
        }

    }
}
