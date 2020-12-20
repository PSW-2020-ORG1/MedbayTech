using System;
using System.Text;
using Xunit;
using Shouldly;
using Model.Users;
using Backend.Records.Model.Enums;
using Backend.Records.WebApiService;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplication;
using System.Net;
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace IntegrationTests.Schedule
{
    public class AppointmentTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AppointmentTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async System.Threading.Tasks.Task ScheduleAppointmentAsync()
        {
            HttpClient client = _factory.CreateClient();
            var appointment = CreateAppointment();
            StringContent content = new StringContent(JsonConvert.SerializeObject(appointment), System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/appointment/schedule", content);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

        }

        public ScheduleAppointmentDTO CreateAppointment()
        {
            return new ScheduleAppointmentDTO
            {
                DoctorId = "2407978890045",
                PatientId = "2406978890046",
                StartTime = new DateTime(2020, 12, 24, 13, 30, 0),
                EndTime =  new DateTime(2020, 12, 24, 14, 0, 0)
            };
        }
    }
}
