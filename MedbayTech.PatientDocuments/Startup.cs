using System;
using Backend.Examinations.Service.Interfaces;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Examinations;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Persistance.Treatments;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Service;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Service.Treatments;
using MedbayTech.PatientDocuments.Infrastructure.Database;
using MedbayTech.PatientDocuments.Infrastructure.Gateways;
using MedbayTech.PatientDocuments.Infrastructure.Persistance;
using MedbayTech.PatientDocuments.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();


            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IReportSearchService, ReportSearchService>();
            services.AddScoped<IPrescriptionSearchService, PrescriptionSearchService>();


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
                    Console.WriteLine("Failed to seed data in Patient Documents");
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
