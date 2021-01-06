using Microsoft.AspNetCore.Mvc.Testing;
using Model.Users;
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
            City city = new City(1, "Novi Sad", new State(1, "Srbija"));
            Address address = new Address(1, "Radnicka", 2, 4, 1, city);
            InsurancePolicy insurancePolicy = new InsurancePolicy { Id = "001", Company = "Dunav Osiguranje", StartTime = new DateTime(2015, 1, 1), EndTime = new DateTime(2025, 1, 1) };

            Patient patient = new Patient("Marko", "Markovic", new DateTime(1975, 6, 9), "2406978890046", "marko@gmail.com", "marko12", "password",
                EducationLevel.bachelor, Gender.MALE, "0123456", "vodoinstalater", city, address, insurancePolicy, false, ".");

            return patient;
        }
    }
}
