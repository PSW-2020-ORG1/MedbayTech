using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory.Gateways
{
    public class AppointmentUserGateway : IAppointmentGateway
    {
        private readonly TestServer _factoryAppointments;

        public AppointmentUserGateway()
        {
            _factoryAppointments = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<MedbayTech.Appointment.Startup>().UseEnvironment("Testing").ConfigureServices(services =>
                {
                    services.Add(new ServiceDescriptor(typeof(IUserGateway), new UserAppointmentGateway()));
                }));
        }
        public List<MedbayTech.Users.Domain.Entites.Appointment> GetAll()
        {
            using HttpClient client = _factoryAppointments.CreateClient();
            List<MedbayTech.Users.Domain.Entites.Appointment> _appointments = new List<MedbayTech.Users.Domain.Entites.Appointment>();
            var task = client.GetAsync(GetUsersDomain() + "/api/appointment/allAppointments")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    _appointments = JsonConvert.DeserializeObject<List<MedbayTech.Users.Domain.Entites.Appointment>>(json.Result);
                });
            task.Wait();

            return _appointments;
        }

        public List<MedbayTech.Users.Domain.Entites.Appointment> GetCancelableAppointmentsBy(string userId)
        {
            throw new NotImplementedException();
        }

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_APPOINTMENT") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_APPOINTMENT") ?? "8083";

            return $"http://{origin}:{port}";
        }
    }
}
