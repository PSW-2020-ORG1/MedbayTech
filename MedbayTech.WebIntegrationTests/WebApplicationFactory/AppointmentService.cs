
using MedbayTech.WebIntegrationTests.WebApplicationFactory.Gateways;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedbayTech.Appointment.Application.Gateways;
using Xunit;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory
{
    public class AppointmentService : WebApplicationFactory<Appointment.Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Appointment.Startup>()
                .UseEnvironment("Testing");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.Add(new ServiceDescriptor(typeof(IUserGateway), new UserAppointmentGateway()));
            });
        }
    }
}
