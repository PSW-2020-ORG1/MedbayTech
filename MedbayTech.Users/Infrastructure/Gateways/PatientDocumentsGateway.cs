using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using MedbayTech.Users.Domain.Entites;
using Newtonsoft.Json;

namespace MedbayTech.Users.Infrastructure.Gateways
{
    public class PatientDocumentsGateway : IPatientDocumentsGateway
    {
        public void SaveMedicalRecord(MedicalRecord medicalRecord)
        {
            using HttpClient client = new HttpClient();
            string response = "";
            StringContent content = new StringContent(JsonConvert.SerializeObject(medicalRecord), System.Text.Encoding.UTF8, "application/json");
            var task = client.PostAsync(GetUsersDomain() + "/api/medicalrecord/save", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                });
            task.Wait();

        }

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "50577";

            return $"http://{origin}:{port}";
        }
    }
}
