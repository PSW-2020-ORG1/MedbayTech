using Backend.Medications.Model;
using Backend.Reports.Controller;
using Backend.Reports.Model;
using Backend.Reports.Repository;
using Backend.Reports.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using PharmacyIntegration;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTests.PhIntegration
{
    public class SendReportNotificationTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SendReportNotificationTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Post_send_report_notification()
        {
            HttpClient client = _factory.CreateClient();
            var medicationUsageReportNotification = CreateMedicationUsageReportNotification();
            StringContent content = new StringContent(JsonConvert.SerializeObject(medicationUsageReportNotification), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/ReportNotification", content);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private MedicationUsageReportNotification CreateMedicationUsageReportNotification()
        {
            MedicationUsageReportNotification medicationUsageReportNotification = new MedicationUsageReportNotification
            {
                Endpoint = "http://l4v.ddns.net:50202/api/httpfilesharing",
                Message = "New usage report from MedbayTech",
                Filename = "165465166841.json",   
            };

            return medicationUsageReportNotification;
        }

        

    }
}
