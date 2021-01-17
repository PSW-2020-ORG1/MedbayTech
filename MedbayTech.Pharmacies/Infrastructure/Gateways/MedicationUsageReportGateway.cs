using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Infrastructure.Gateways
{
    public class MedicationUsageReportGateway : IMedicationUsageReportGateway
    {
        public List<MedicationUsageReport> GetAll()
        {
            List<MedicationUsageReport> prescriptions = new List<MedicationUsageReport>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "/api/medicationusagereport")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    prescriptions = JsonConvert.DeserializeObject<List<MedicationUsageReport>>(json.Result);
                });
            task.Wait();
            return prescriptions;
        }

        private string GetMedicationDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_MEDICATION") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_MEDICATION") ?? "56764";

            return $"http://{origin}:{port}";
        }
    }
}
