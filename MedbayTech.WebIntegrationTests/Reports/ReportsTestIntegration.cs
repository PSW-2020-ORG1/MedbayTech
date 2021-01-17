using MedbayTech.PatientDocuments.Application.DTO.Report;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using MedbayTech.PatientDocuments;
using Xunit;

namespace MedbayTech.WebIntegrationTests.Reports
{
    public class ReportsTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;


        public ReportsTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async System.Threading.Tasks.Task Get_Report_For_Appointment_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();
            var appointment = Appointment();
            StringContent content = new StringContent(JsonConvert.SerializeObject(appointment), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/report/appointmentReport", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);

        }

        private static AppointmentDTO Appointment()
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO
            {
                StartTime = new DateTime(2020, 12, 1, 14, 00, 0),
                DoctorId = "2407978890045"
            };
            return appointmentDTO;
        }
    }
}
