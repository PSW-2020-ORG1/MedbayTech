using Backend.Utils.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Model.Users;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using WebApplication;
using Xunit;

namespace IntegrationTests.Schedules
{
    public class CancelAppointmentTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CancelAppointmentTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async System.Threading.Tasks.Task Find_patients_surveyable_appointments_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();
            var id = AppointmentId();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/appointment/cancelAppointment", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private static CancelAppointmentDTO AppointmentId()
        {
            CancelAppointmentDTO cancelDTO = new CancelAppointmentDTO
            {
                AppointmentId = 5
            };

            return cancelDTO;
        }
    }
}
