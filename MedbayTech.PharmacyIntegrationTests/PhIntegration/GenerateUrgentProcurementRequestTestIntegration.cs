using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Backend.Pharmacies.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PharmacyIntegration;
using Shouldly;
using Xunit;

namespace PhIntegrationTests.PhIntegration
{
    public class GenerateUrgentProcurementRequestTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;
        public GenerateUrgentProcurementRequestTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Generate_urgent_procurement_request()
        {
            Console.WriteLine("Started request testing");
            HttpClient client = _factory.CreateClient();
            var procurement = CreateUrgentProcurement();
            StringContent content = new StringContent(JsonConvert.SerializeObject(procurement), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Procurement", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private UrgentMedicationProcurement CreateUrgentProcurement()
        {
            UrgentMedicationProcurement procurement = new UrgentMedicationProcurement
            {
                MedicationName = "Lidokain",
                MedicationDosage = "10mg",
                MedicationQuantity = 2,
            };
            return procurement;
        }
    }
}
