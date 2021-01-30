using Microsoft.AspNetCore;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Application.DTO;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using Microsoft.Extensions.DependencyInjection;


namespace MedbayTech.WebIntegrationTests.WebApplicationFactory.Gateways
{

    public class UserAppointmentGateway : IUserGateway
    {
        private readonly TestServer _factoryUsers;

        public UserAppointmentGateway()
        {
            _factoryUsers = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<MedbayTech.Users.Startup>());

        }

        public List<Appointment.Domain.Entities.Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Appointment.Domain.Entities.Doctor GetDoctorBy(string id)
        {
            Doctor doctor = null;
            using HttpClient client = _factoryUsers.CreateClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/doctor/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    doctor = JsonConvert.DeserializeObject<Doctor>(json.Result);
                });
            task.Wait();

            return doctor;
        }

        public List<Appointment.Domain.Entities.Doctor> GetDoctorsBy(int specializationId)
        {
            throw new NotImplementedException();
        }

        public Appointment.Domain.Entities.Patient GetPatientBy(string id)
        {
            Patient patient = null;
            using HttpClient client = _factoryUsers.CreateClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/patient/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    patient = JsonConvert.DeserializeObject<Patient>(json.Result);
                });
            task.Wait();

            return patient;
        }

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_USERS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_USERS") ?? "8081";

            return $"http://{origin}:{port}";
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
    }
}
