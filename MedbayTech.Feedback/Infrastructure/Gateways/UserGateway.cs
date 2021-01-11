using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MedbayTech.Feedback.Application.Common.Interfaces.Gateways;
using MedbayTech.Feedback.Domain.Entities;
using Newtonsoft.Json;

namespace MedbayTech.Feedback.Infrastructure.Gateways
{
    public class UserGateway : IUserGateway
    {

        private List<User> _users { get; set; }

        public List<User> GetUsers()
        {
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    _users = JsonConvert.DeserializeObject<List<User>>(json.Result);
                });
            task.Wait();
            return _users;

        }

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_USERS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_USERS") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
