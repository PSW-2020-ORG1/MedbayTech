using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using PharmacyIntegration.Service;
using PharmacyIntegration.Repository;
using Backend.Pharmacies.Repository.MySqlRepository;

namespace RabbitMQService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {

                     services.AddDbContext<MedbayTechDbContext>();
                     services.AddScoped<IPharmacyNotificationRepository, PharmacyNotificationSqlRepository>();
                     services.AddTransient<IPharmacyRepository, PharmacySqlRepository>();
                     services.AddTransient<IPharmacyNotificationService, PharmacyNotificationService>(); 
                     services.AddHostedService<RabbitMQHosedService>();
                });
    }
}
