using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Records.Service.Interfaces;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Infrastructure.Database;
using MedbayTech.PatientDocuments.Infrastructure.Gateways;
using MedbayTech.PatientDocuments.Infrastructure.Persistance;
using MedbayTech.PatientDocuments.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository.MedicalRecordRepository;

namespace MedbayTech.PatientDocuments
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
            services.AddDbContext<PatientDocumentsDbContext>();

            services.AddControllers();

            services.AddTransient<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();


            services.AddScoped<IUserGateway, UserGateway>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<PatientDocumentsDbContext>())
            {
                try
                {
                    PatientDocumentsDataSeeder seeder = new PatientDocumentsDataSeeder();
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
