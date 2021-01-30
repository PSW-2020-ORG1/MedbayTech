using System;
using System.Collections.Generic;
using System.Text;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using MedbayTech.WebIntegrationTests.WebApplicationFactory.Gateways;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using IUserGateway = MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways.IUserGateway;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory
{
    public class MedicalRecordService : WebApplicationFactory<MedbayTech.PatientDocuments.Startup>
    {
        private readonly TestServer _factoryUsers;
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<MedbayTech.PatientDocuments.Startup>()
                .UseEnvironment("Testing");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.Add(new ServiceDescriptor(typeof(IUserGateway), new UserPatientDocumentsGateway()));
            });
        }
    }
}
