using MedbayTech.Pharmacies.Application.Common.Interfaces.Gateways;
using MedbayTech.Pharmacies.Domain.Entities.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Infrastructure.Gateways
{
    public class MedicationUsageGateway : IMedicationUsageGateway
    {
        public MedicationUsage Add(MedicationUsage usage)
        {
            MedicationUsage retval = null;
            using HttpClient client = new HttpClient();
            string serializedUsage = JsonConvert.SerializeObject(usage);
            var content = new StringContent(serializedUsage, Encoding.UTF8, "application/json");
            var task = client.PostAsync(GetMedicationDomain() + "/api/medicationusage/", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    retval = JsonConvert.DeserializeObject<MedicationUsage>(json.Result);
                });
            task.Wait();
            return retval;
        }

        public MedicationUsage GetBy(int id)
        {
            MedicationUsage usage = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "/api/medicationusage" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    usage = JsonConvert.DeserializeObject<MedicationUsage>(json.Result);
                });
            task.Wait();
            return usage;
        }
        public List<MedicationUsage> GetAll()
        {
            List<MedicationUsage> usages = new List<MedicationUsage>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "/api/medicationusage")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    usages = JsonConvert.DeserializeObject<List<MedicationUsage>>(json.Result);
                });
            task.Wait();
            return usages;
        }

        private string GetMedicationDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_MEDICATION") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_MEDICATION") ?? "56764";
            return $"http://{origin}:{port}";
        }
    }
}
