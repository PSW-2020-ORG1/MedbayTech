using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory
{
    class RoomsService 
    {
        private readonly TestServer _server;
        

        public RoomsService()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Rooms.Startup>());

        }

        public HttpClient CreateClient()
        {
            return _server.CreateClient();
        }

    }
}
