using MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways;
using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using MedbayTech.PatientDocuments.Domain.Entities.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Infrastructure.Gateways
{
    public class UserGateway : IUserGateway
    {
        public Patient GetPatientBy(string id)
        {
            Patient patient = new Patient();
            using HttpClient client = new HttpClient();
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

        public Doctor GetDoctorBy(string id)
        {
            Doctor doctor = new Doctor();
            using HttpClient client = new HttpClient();
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

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_USERS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_USERS") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
