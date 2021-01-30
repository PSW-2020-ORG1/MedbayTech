using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MedbayTech.Appointment.Infrastructure.Gateway
{
    public class RoomGateway : IRoomGateway
    {
        public List<HospitalEquipment> GetAllHospitalEquipments()
        {
            List<HospitalEquipment> hospitalEquipments = new List<HospitalEquipment>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetRoomsDomain() + "/api/hospitalEquipment/getAllHospitalEquipments")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    hospitalEquipments = JsonConvert.DeserializeObject<List<HospitalEquipment>>(json.Result);
                });
            task.Wait();

            return hospitalEquipments;
        }

        public List<HospitalEquipment> GetHospitalEquipmentByRoom(int id)
        {
            List<HospitalEquipment> hospitalEquipments = new List<HospitalEquipment>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetRoomsDomain() + "/api/hospitalEquipment/getAllHospitalEquipments/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    hospitalEquipments = JsonConvert.DeserializeObject<List<HospitalEquipment>>(json.Result);
                });
            task.Wait();

            return hospitalEquipments;

        }

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
            string origin = Environment.GetEnvironmentVariable("URL_ROOMS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_ROOMS") ?? "60304";

            return $"http://{origin}:{port}";
        }
    }
}
