using System;
using System.Text;
using Xunit;
using Shouldly;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using Application.DTO;
using Newtonsoft.Json;
using MedbayTech.WebIntegrationTests.WebApplicationFactory;

namespace MedbayTech.WebIntegrationTests.Schedules
{
    public class AppointmentTests : IClassFixture<AppointmentService>, IClassFixture<LoginService>
    {
        private readonly AppointmentService _factoryAppointment;
        private readonly LoginService _factoryLogin;

        public AppointmentTests(AppointmentService factoryAppointment, LoginService factoryLogin)
        {
            _factoryAppointment = factoryAppointment;
            _factoryLogin = factoryLogin;
        }

        [Fact]
        public async System.Threading.Tasks.Task ScheduleAppointmentAsync()
        {
            HttpClient clientAppointment = _factoryAppointment.CreateClient();
            string token = _factoryLogin.Login("pera", "pera1978");
            
            clientAppointment.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var appointment = CreateAppointment();
            StringContent content = new StringContent(JsonConvert.SerializeObject(appointment), Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await clientAppointment.PostAsync("api/appointment/schedule", content);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

        }

        public ScheduleAppointmentDTO CreateAppointment()
        {
            return new ScheduleAppointmentDTO
            {
                DoctorId = "2406978890047",
                PatientId = "2406978890046",
                StartTime = new DateTime(2021, 12, 28, 13, 30, 0),
                EndTime = new DateTime(2021, 12, 28, 14, 0, 0)
            };
        }
    }
}
