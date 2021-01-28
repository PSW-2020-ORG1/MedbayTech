
using Backend.Utils.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using MedbayTech.Users.Infrastructure.Service;
using MedbayTech.WebIntegrationTests.WebApplicationFactory;
using WebApplication;
using Xunit;


namespace MedbayTech.WebIntegrationTests.Users
{
    public class PatientBlockingTestIntegration : IClassFixture<UsersService>, IClassFixture<LoginService>
    {
        private readonly UsersService _factoryUserService;
        private readonly LoginService _factoryLogin;

        public PatientBlockingTestIntegration(UsersService factoryUserService, LoginService factoryLogin)
        {
            _factoryUserService = factoryUserService;
            _factoryLogin = factoryLogin;
        }

        [Fact]
        public async System.Threading.Tasks.Task Block_malicious_patients_IntegrationAsync()
        {
            HttpClient client = _factoryUserService.CreateClient();
            string token = _factoryLogin.Login("markic", "marko1978");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var id = PatientId();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/patient/updatePatientStatus", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private static UpdatePatientBlockedStatusDTO PatientId()
        {
            UpdatePatientBlockedStatusDTO statusDTO = new UpdatePatientBlockedStatusDTO
            {
                Id = "2406978890046"
            };

            return statusDTO;
        }
    }
}
