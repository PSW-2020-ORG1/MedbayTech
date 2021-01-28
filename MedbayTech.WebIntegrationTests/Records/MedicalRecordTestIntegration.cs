using System;
using Xunit;
using Shouldly;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;
using MedbayTech.WebIntegrationTests.WebApplicationFactory;
using WebApplication;
using Model.Users;

namespace MedbayTech.WebIntegrationTests.Records
{

    public class MedicalRecordTestIntegration : IClassFixture<MedicalRecordService>, IClassFixture<LoginService>
    {
        private readonly MedicalRecordService _factoryMedicalRecordService;
        private readonly LoginService _factoryLoginService;
        public MedicalRecordTestIntegration(MedicalRecordService factoryMedicalRecordService, LoginService factoryLoginService)
        {
            _factoryMedicalRecordService = factoryMedicalRecordService;
            _factoryLoginService = factoryLoginService;
        }
        [Fact]
        public async System.Threading.Tasks.Task Find_patients_medical_record_IntegrationAsync()
        {
            HttpClient client = _factoryMedicalRecordService.CreateClient();
            string token = _factoryLoginService.Login("pera", "pera1978");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
