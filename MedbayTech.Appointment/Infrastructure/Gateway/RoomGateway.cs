using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace MedbayTech.Appointment.Infrastructure.Gateway
{
    public class RoomGateway : IRoomGateway
    {
        public Room GetRoomBy(int roomId)
        {
            Room room = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetRoomsDomain() + "/api/room/" + roomId)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    room = JsonConvert.DeserializeObject<Room>(json.Result);
                });
            task.Wait();

            return room;
        }

        public string GetRoomsDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "60304";

            return $"http://{origin}:{port}";
        }
    }
}
