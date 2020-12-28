
using MedbayTech.Appointment.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MedbayTech.Appointment.Infrastructure.Gateway
{
    public class DoctorGateway
    {
        private List<Doctor> _doctors { get; set; }

        public List<Doctor> GetDoctors()
        {
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetDoctorsDomain() + "/api/doctor")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    _doctors = JsonConvert.DeserializeObject<List<Doctor>>(json.Result);
                });
            task.Wait();

            return _doctors;
        }

        public string GetDoctorsDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
