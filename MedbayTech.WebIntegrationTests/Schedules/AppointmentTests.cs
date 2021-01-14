using System;
using System.Text;
using Xunit;
using Shouldly;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Newtonsoft.Json;
using MedbayTech.WebIntegrationTests.WebApplicationFactory;

namespace MedbayTech.WebIntegrationTests.Schedules
{/*
    public class AppointmentTests : IClassFixture<AppointmentService>
    {
        private readonly AppointmentService _factoryAppointment;

        public AppointmentTests(AppointmentService factory)
        {
            _factoryAppointment = factory;
        }

        [Fact]
        public async System.Threading.Tasks.Task ScheduleAppointmentAsync()
        {
            HttpClient clientAppointment = _factoryAppointment.CreateClient();
            
            var appointment = CreateAppointment();
            StringContent content = new StringContent(JsonConvert.SerializeObject(appointment), Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await clientAppointment.PostAsync("api/appointment/schedule", content);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

        }

        public ScheduleAppointmentDTO CreateAppointment()
        {
            return new ScheduleAppointmentDTO
            {
                DoctorId = "2407978890041",
                PatientId = "2406978890046",
                StartTime = new DateTime(2021, 01, 16, 08, 0, 0),
                EndTime = new DateTime(2021, 01, 16, 08, 30, 0)
            };
        }
    }*/
}
