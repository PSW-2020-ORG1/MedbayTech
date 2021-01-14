using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Net.Http;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using WebApplication;

namespace MedbayTech.WebIntegrationTests.Users
{/*
    public class LoginTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public LoginTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async System.Threading.Tasks.Task Login_IntegrationAsync()
        {
            HttpClient client = _factory.CreateClient();
            var user = LoggedUser();
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/authentication/authenticate", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private static AuthenticationDTO LoggedUser()
        {
            AuthenticationDTO userDTO = new AuthenticationDTO
            {
                Username = "pera",
                Password = "pera1978"
            };

            return userDTO;
        }
    }*/
}
