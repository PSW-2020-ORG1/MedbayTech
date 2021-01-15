using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies.Domain.Entities.Medications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Infrastructure.Gateways
{
    public class MedicationGateway : IMedicationGateway
    {

        public Medication Create(Medication medication)
        {
            Medication retval = null;
            NewMedicationDTO dto = new NewMedicationDTO(medication.Med, medication.Dosage);
            string serializedDto = JsonConvert.SerializeObject(dto);
            var content = new StringContent(serializedDto, Encoding.UTF8, "application/json");
            using HttpClient client = new HttpClient();
            var task = client.PostAsync(GetMedicationDomain() + "/api/medication/", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    retval = JsonConvert.DeserializeObject<Medication>(json.Result);
                });
            task.Wait();
            return retval;
        }

        public Medication Update(Medication medication)
        {
            Medication retval = null;
            using HttpClient client = new HttpClient();
            string serializedMed = JsonConvert.SerializeObject(medication);
            var content = new StringContent(serializedMed, Encoding.UTF8, "application/json");
            var task = client.PostAsync(GetMedicationDomain() + "/api/medication/", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    retval = JsonConvert.DeserializeObject<Medication>(json.Result);
                });
            task.Wait();
            return retval;
        }

        public Medication GetBy(int id)
        {
            Medication medication = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "api/medication/" + id)
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
