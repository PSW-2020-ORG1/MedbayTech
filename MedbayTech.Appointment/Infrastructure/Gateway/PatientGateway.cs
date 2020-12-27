using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Infrastructure.Gateway
{
    public class PatientGateway
    {
        private Patient _patient { get; set; }

        public Patient GetPatientBy(string id)
        {
            /*  using HttpClient client = new HttpClient();
              var task = client.PostAsync()
                  .ContinueWith((taskWithResponse) =>
                  {
                      var message = taskWithResponse.Result;
                      var json = message.Content.ReadAsStringAsync();
                      json.Wait();
                      _patient = JsonConvert.DeserializeObject<Patient>(json.Result);
                  });
              task.Wait();

              return _patient; */
            throw new NotImplementedException();
        }

        public string GetPatientsDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
