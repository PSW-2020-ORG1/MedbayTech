using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces.Persistance;
using Application.Common.Interfaces.Service;
using Infrastructure.Database;
using Infrastructure.Services;
using MedbayTech.Appointment.Application.Common.Interfaces.Persistance;
using MedbayTech.Appointment.Infrastructure.Persistance;
using MedbayTech.Appointment.Infrastructure.Gateway;
using MedbayTech.Appointment.Application.Gateways;

namespace MedbayTech.Appointment
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<AppointmentDbContext>();

            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<ISurveyRepository, SurveyRepository>();
            
            
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IUserGateway, UserGateway>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppointmentDbContext>())
            {
                try
                {
                    AppointmentDataSeeder seeder = new AppointmentDataSeeder();
                    if (!seeder.IsAlreadyFull(context))
                        seeder.SeedAllEntities(context);

                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to seed data");
                }
            }
        }
    }
}
