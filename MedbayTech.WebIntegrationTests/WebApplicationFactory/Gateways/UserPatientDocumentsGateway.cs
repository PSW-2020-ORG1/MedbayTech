using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using MedbayTech.PatientDocuments.Domain.Entities.Users;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory.Gateways
{
    public class UserPatientDocumentsGateway : IUserGateway
    {
        private readonly TestServer _factoryUsers;

        public UserPatientDocumentsGateway()
        {
            _factoryUsers = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<MedbayTech.Users.Startup>());
        }
        public Doctor GetDoctorBy(string id)
        {
            Doctor doctor = new Doctor();
            using HttpClient client = _factoryUsers.CreateClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    doctor = JsonConvert.DeserializeObject<Doctor>(json.Result);
                });
            task.Wait();

            return doctor;
        }

        public Patient GetPatientBy(string id)
        {
            Patient patient = new Patient();
            using HttpClient client = _factoryUsers.CreateClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    patient = JsonConvert.DeserializeObject<Patient>(json.Result);
                });
            task.Wait();


            return patient;
        }

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_USERS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_USERS") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
