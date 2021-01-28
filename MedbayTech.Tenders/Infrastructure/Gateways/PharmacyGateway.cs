using MedbayTech.Tenders.Application.Common.Interfaces.Gateways;
using MedbayTech.Tenders.Domain.Entities.Pharmacies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedbayTech.Tenders.Infrastructure.Gateways
{
    public class PharmacyGateway : IPharmacyGateway
    {
        public Pharmacy Get(string id)
        {
            Pharmacy pharmacy = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetPharmacyDomain() + "/api/pharmacy/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    pharmacy = JsonConvert.DeserializeObject<Pharmacy>(json.Result);
                });
            task.Wait();
            return pharmacy;
        }

        public List<Pharmacy> GetAll()
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetPharmacyDomain() + "/api/pharmacy")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    pharmacies = JsonConvert.DeserializeObject<List<Pharmacy>>(json.Result);
                });
            task.Wait();
            return pharmacies;
        }

        private string GetPharmacyDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_PHARMACIES") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_PHARMACIES") ?? "50202";

            return $"http://{origin}:{port}";
        }
    }
}
