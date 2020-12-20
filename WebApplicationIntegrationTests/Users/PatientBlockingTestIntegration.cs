using Backend.Utils.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using WebApplication;
using Xunit;

namespace IntegrationTests.Users
{
    public class PatientBlockingTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PatientBlockingTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async System.Threading.Tasks.Task Get_all_blockable_patients_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/patient/maliciousPatients");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async System.Threading.Tasks.Task Block_malicious_patients_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();
            var id = PatientId();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/patient/updatePatientStatus", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private static UpdatePatientBlockedStatusDTO PatientId()
        {
            UpdatePatientBlockedStatusDTO statusDTO = new UpdatePatientBlockedStatusDTO
            {
                Id = "2406978890046"
            };

            return statusDTO;
        }
    }
}
