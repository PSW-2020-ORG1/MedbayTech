using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using MedbayTech.WebIntegrationTests.WebApplicationFactory.Gateways;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory
{
    public class UsersService : WebApplicationFactory<MedbayTech.Users.Startup>
    {
        private readonly TestServer _factoryUsers;
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<MedbayTech.Users.Startup>()
                .UseEnvironment("Testing");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.Add(new ServiceDescriptor(typeof(IAppointmentGateway), new AppointmentUserGateway()));
            });
        }
    }
}
