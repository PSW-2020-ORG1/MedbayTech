using MedbayTech.Rooms.Application.Common.Interfaces.Gateways;
using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;


namespace MedbayTech.Rooms.Infrastructure.Gateway
{
    public class UserGateway : IUserGateway
    {
        public Doctor GetDoctorByRoomExaminationRoom(int roomId)
        {
            Doctor doctor = new Doctor();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "api/user/getByRoom/" + roomId)
                .ContinueWith((tasktaskWithResponse) =>
                {
                    var message = tasktaskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    doctor = JsonConvert.DeserializeObject<Doctor>(json.Result);
                });

            return doctor;
        }

        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "api/doctor")
                 .ContinueWith((tasktaskWithResponse) =>
                 {
                     var message = tasktaskWithResponse.Result;
                     var json = message.Content.ReadAsStringAsync();
                     json.Wait();
                     doctors = JsonConvert.DeserializeObject<List<Doctor>>(json.Result);

                 });

            return doctors;
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "api/patient")
                 .ContinueWith((tasktaskWithResponse) =>
                 {
                     var message = tasktaskWithResponse.Result;
                     var json = message.Content.ReadAsStringAsync();
                     json.Wait();
                     patients = JsonConvert.DeserializeObject<List<Patient>>(json.Result);

                 });

            return patients;
        }

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
