using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using MedbayTech.Users.Domain.Entites;
using Newtonsoft.Json;

namespace MedbayTech.Users.Infrastructure.Gateways
{
    public class AppointmentGateway : IAppointmentGateway
    {
        private List<Appointment> _appointments { get; set; }

        public List<Appointment> GetAll()
        {
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/appointment/allAppointments")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    _appointments = JsonConvert.DeserializeObject<List<Appointment>>(json.Result);
                });
            task.Wait();

            return _appointments;
        }

        public List<Appointment> GetCancelableAppointmentsBy(string userId)
        {
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/appointment/appointmentsUser/" + userId)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    _appointments = JsonConvert.DeserializeObject<List<Appointment>>(json.Result);
                });
            task.Wait();

            return _appointments;

        }


        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_APPOINTMENT") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_APPOINTMENT") ?? "8083";

            return $"http://{origin}:{port}";
        }
    }
}
