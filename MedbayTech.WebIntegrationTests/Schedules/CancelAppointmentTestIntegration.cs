
using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Text;
using Application.DTO;
using MedbayTech.Appointment;
using WebApplication;
using Xunit;

namespace MedbayTech.WebIntegrationTests.Schedules
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
            Console.Write("Started find patients surveyable appointmenst");
            HttpClient client = _factory.CreateClient();
            var id = AppointmentId();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/appointment/cancelAppointment", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            Console.Write("Finished find patients surveyable appointmenst");
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
