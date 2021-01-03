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
            services.AddDbContext<RoomDbContext>();
            services.AddControllers();
            services.AddScoped<IBedService, BedService>();
            services.AddScoped<IDepartmentService,DepartmentService>();
            services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
            services.AddScoped<IHospitalEquipmentService, HospitalEquipmentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRenovationService, RenovationService>();

            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<RoomDbContext>())
            {
                try
                {
                    RoomDataSeeder seeder = new RoomDataSeeder();
                    if (!seeder.IsAlreadyFull(context))
                        seeder.SeedAllEntities(context);

                }
                catch (Exception)
                {

                }

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}
