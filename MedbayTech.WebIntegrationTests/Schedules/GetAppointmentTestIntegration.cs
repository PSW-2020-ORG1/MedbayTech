using MedbayTech.Appointment;
using MedbayTech.Appointment.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Model.Users;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace MedbayTech.WebIntegrationTests.Schedules
{
    public class GetAppointmentTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetAppointmentTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async System.Threading.Tasks.Task Find_patients_surveyable_appointments_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();

            var patient = CreatePatient();

            HttpResponseMessage response = await client.GetAsync("api/appointment/allSurveyableAppointments");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async System.Threading.Tasks.Task Find_patients_all_other_appointments_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();

            var patient = CreatePatient();

            HttpResponseMessage response = await client.GetAsync("api/appointment/allOtherAppointments");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async System.Threading.Tasks.Task Find_patients_cancelable_appointments_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();

            var patient = CreatePatient();

            HttpResponseMessage response = await client.GetAsync("api/appointment/allCancelableAppointments");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private static Patient CreatePatient()
        {
            Patient patient = new Patient
            {
                Id = "2406978890046",
                Name = "Marko",
                Surname = "Markovic",
                DateOfBirth = new DateTime(1975, 6, 9),
                ChosenDoctor = new Doctor(),
                Blocked = false,
                ShouldBeBlocked = false
            };

            return patient;
        }
    }
}
