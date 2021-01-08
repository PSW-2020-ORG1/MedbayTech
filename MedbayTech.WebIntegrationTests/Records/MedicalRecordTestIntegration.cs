using System;
using Xunit;
using Shouldly;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using MedbayTech.PatientDocuments;
using MedbayTech.PatientDocuments.Domain.Entities.Patient;


namespace MedbayTech.WebIntegrationTests.Records
{

    public class MedicalRecordTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public MedicalRecordTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async System.Threading.Tasks.Task Find_patients_medical_record_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();


            var patient = CreatePatient();

            HttpResponseMessage response = await client.GetAsync("api/medicalRecord");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private static Patient CreatePatient()
        {
            var patient = new Patient
            {
                Id = "2406978890046",
                DateOfBirth = new DateTime(1978, 6, 24),
                Email = "pera@gmail.com",
                Name = "Petar",
                Surname = "Petrovic",
                Phone = "065/123-4554",
                ProfileImage = ".",
            };

            return patient;
        }
    }
}
