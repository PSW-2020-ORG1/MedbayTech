using MedbayTech.PharmacyIntegrationTests.PhIntegration.WebApplicationFactory.Gateways;
using MedbayTech.Tenders;
using MedbayTech.Tenders.Application.Common.Interfaces.Gateways;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.PharmacyIntegrationTests.PhIntegration.WebApplicationFactory
{
    public class TenderFactory : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Testing");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.Add(new ServiceDescriptor(typeof(IPharmacyGateway), new PharmacyTenderGateway()));
            });
        }
    }
}
