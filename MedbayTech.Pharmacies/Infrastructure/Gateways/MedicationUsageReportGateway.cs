using MedbayTech.Common.Domain.ValueObjects;
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
    public class MedicationUsageReportGateway : IMedicationUsageReportGateway
    {

        public MedicationUsageReport Generate(Period period)
        {
            MedicationUsageReport report = null;
            using HttpClient client = new HttpClient();
            string serializedReport = JsonConvert.SerializeObject(period);
            var content = new StringContent(serializedReport, Encoding.UTF8, "application/json");
            var task = client.PostAsync(GetMedicationDomain() + "/api/medicationusagereport", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    report = JsonConvert.DeserializeObject<MedicationUsageReport>(json.Result);
                });
            task.Wait();
            return report;
        }

        public MedicationUsageReport Add(MedicationUsageReport report)
        {
            MedicationUsageReport retval = null;
            using HttpClient client = new HttpClient();
            string serializedReport = JsonConvert.SerializeObject(report);
            var content = new StringContent(serializedReport, Encoding.UTF8, "application/json");
            var task = client.PostAsync(GetMedicationDomain() + "/api/medicationusagereport", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    retval = JsonConvert.DeserializeObject<MedicationUsageReport>(json.Result);
                });
            task.Wait();
            return retval;
        }

        public List<MedicationUsageReport> GetAll()
        {
            List<MedicationUsageReport> usages = new List<MedicationUsageReport>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "/api/medicationusagereport")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    usages = JsonConvert.DeserializeObject<List<MedicationUsageReport>>(json.Result);
                });
            task.Wait();
            return usages;
        }

        public MedicationUsageReport GetBy(string id)
        {
            MedicationUsageReport usage = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicationDomain() + "/api/medicationusagereport" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    usage = JsonConvert.DeserializeObject<MedicationUsageReport>(json.Result);
                });
            task.Wait();
            return usage;
        }

        private string GetMedicationDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_MEDICATION") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_MEDICATION") ?? "56764";
            return $"http://{origin}:{port}";
        }
    }
}
