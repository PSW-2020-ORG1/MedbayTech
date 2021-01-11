using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Application.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MedbayTech.Pharmacies.Infrastructure.Gateways
{
    public class PrescriptionGateway : IPrescriptionGateway
    {
        public string GeneratePrescription(PrescriptionForSendingDTO prescription)
        {
            string generatedPrescription = "";
            using HttpClient client = new HttpClient();
            string serializedDto = JsonConvert.SerializeObject(prescription);

            var content = new StringContent(serializedDto, Encoding.UTF8, "application/json");

            var task = client.PostAsync(GetPrescriptionDomain() + "/api/prescription/generate", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    generatedPrescription = JsonConvert.DeserializeObject<string>(json.Result);
                });
            task.Wait();

            return generatedPrescription;
        }

        public List<PrescriptionForSendingDTO> GetAll()
        {
            List<PrescriptionForSendingDTO> prescriptions = new List<PrescriptionForSendingDTO>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetPrescriptionDomain() + "/api/prescription/all")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    prescriptions = JsonConvert.DeserializeObject<List<PrescriptionForSendingDTO>>(json.Result);
                });
            task.Wait();
            return prescriptions;

        }

        private string GetPrescriptionDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_DOCUMENTS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_DOCUMENTS") ?? "50577";

            return $"http://{origin}:{port}";
        }
    }
}
