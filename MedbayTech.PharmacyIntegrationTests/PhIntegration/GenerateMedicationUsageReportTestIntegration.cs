using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PharmacyIntegration;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Backend.Utils;
using System.Transactions;
using Model;

namespace IntegrationTests.PhIntegration
{
    public class GenerateMedicationUsageReportTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public GenerateMedicationUsageReportTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Post_generate_medication_usage_report()
        {
        
            HttpClient client = _factory.CreateClient();
            var period = CreatePeriod();
            StringContent content = new StringContent(JsonConvert.SerializeObject(period), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/MedicationUsageReport", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private Period CreatePeriod()
        {
            Period period = new Period
            {
                StartTime = new DateTime(2020, 8, 15), 
                EndTime = new DateTime(2020, 9, 16),
            };
            return period;
        }

    }
}
