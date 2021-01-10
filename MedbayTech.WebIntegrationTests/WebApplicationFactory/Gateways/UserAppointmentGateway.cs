using Microsoft.AspNetCore;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MedbayTech.WebIntegrationTests.WebApplicationFactory.Gateways
{/*

    class UserAppointmentGateway : IUserGateway
    {
        private readonly TestServer _factoryUsers;
        public UserAppointmentGateway()
        {
            _factoryUsers = new TestServer(WebHost.CreateDefaultBuilder()
                   .UseStartup<MedbayTech.Users.Startup>());

        }
        public List<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorBy(string id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsBy(int specializationId)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientBy(string id)
        {
            throw new NotImplementedException();
        }

        public string GetUsersDomain()
        {
            throw new NotImplementedException();
        }

        public WorkDay GetWorkDayBy(string id, DateTime date)
        {
            WorkDay workDay = null;
            WorkDayDTO dto = new WorkDayDTO(id, date);
            using HttpClient client = _factoryUsers.CreateClient();
            string serializedDto = JsonConvert.SerializeObject(dto);

            var content = new StringContent(serializedDto, Encoding.UTF8, "application/json");

            var task = client.PostAsync("/api/workDay/", content)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    workDay = JsonConvert.DeserializeObject<WorkDay>(json.Result);
                });
            task.Wait();

            return workDay;
        }
    }*/

}
