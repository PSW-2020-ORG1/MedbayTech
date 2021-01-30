using MedbayTech.Tenders.Application.Common.Interfaces.Gateways;
using MedbayTech.Tenders.Domain.Entities.Medications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MedbayTech.Tenders.Infrastructure.Gateways
{
    public class MedicationGateway : IMedicationGateway
    {

        public Medication Get(int id)
        {
            Medication medication = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "/api/medication/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    medication = JsonConvert.DeserializeObject<Medication>(json.Result);
                });
            task.Wait();
            return medication;
        }

        public List<Medication> GetAll()
        {
            List<Medication> medications = new List<Medication>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "/api/medication/all")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    medications = JsonConvert.DeserializeObject<List<Medication>>(json.Result);
                });
            task.Wait();

            return medications;
        }

        private string GetMedicationDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_MEDICATION") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_MEDICATION") ?? "56764";

            return $"http://{origin}:{port}";
        }
    }
}
