using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedbayTech.Users.Application.DTO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory
{
    public class LoginService : WebApplicationFactory<MedbayTech.Users.Startup>
    {
        private readonly TestServer _factoryUsers;

        public LoginService()
        {
            _factoryUsers = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<MedbayTech.Users.Startup>());
        }
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<MedbayTech.Users.Startup>();
        }

        public string Login(string username, string password)
        {
            string token = null;
            AuthenticationDTO dto = new AuthenticationDTO(username, password);
            using HttpClient client = _factoryUsers.CreateClient();
            AuthenticatedUserDTO auteAuthenticatedUserDto = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");
            var task = client.PostAsync(GetUsersDomain() + "/api/authentication/authenticate", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    auteAuthenticatedUserDto = JsonConvert.DeserializeObject<AuthenticatedUserDTO>(json.Result);
                    token = auteAuthenticatedUserDto.Token;
                });
            task.Wait();

            return token;
        }

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_USERS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_USERS") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
