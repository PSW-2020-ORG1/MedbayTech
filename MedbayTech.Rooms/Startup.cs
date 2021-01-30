using MedbayTech.Rooms.Application.Common;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Application.Common.Interfaces.Service;
using MedbayTech.Rooms.Application.Common.Service;
using MedbayTech.Rooms.Infrastructure.Database;
using MedbayTech.Rooms.Infrastructure.Persistance;
using MedbayTech.Rooms.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MedbayTech.Rooms
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

            services.AddDbContext<RoomDbContext>();
            services.AddControllers();

            //services.AddScoped<IBedService, BedService>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService,DepartmentService>();

            services.AddTransient<IEquipmentTypeRepository, EquipmentTypeRepository>();
            services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();

            services.AddTransient<IHospitalEquipmentRepository, HospitalEquipmentRepository>();
            services.AddScoped<IHospitalEquipmentService, HospitalEquipmentService>();

            //services.AddScoped<INotificationService, NotificationService>();
            //services.AddScoped<IRenovationService, RenovationService>();

            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddTransient<IRoomEventRepository, RoomEventRepository>();
            services.AddScoped<IRoomEventService, RoomEventService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "development";
            string host = Environment.GetEnvironmentVariable("DATABASE_TYPE") ?? "localhost";

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<RoomDbContext>())
            {
                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();

                try
                {
                    if (!stage.Equals("development") && host.Equals("postgres"))
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
                
                    RoomDataSeeder seeder = new RoomDataSeeder();
                    if (!seeder.IsAlreadyFull(context))
                        seeder.SeedAllEntities(context);

                





                app.UseRouting();

                app.UseCors("AllowAll");
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}
