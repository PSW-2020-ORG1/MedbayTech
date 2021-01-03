
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MedbayTech.Appointment.Infrastructure.Gateway
{
    public class UserGateway : IUserGateway
    {
        public Doctor GetDoctorBy(string id)
        {
            Doctor doctor = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user")
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

        public List<Doctor> GetDoctorsBy(string specializationName)
        {
            List<Doctor> doctors = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    doctors = JsonConvert.DeserializeObject<List<Doctor>>(json.Result);
                });
            task.Wait();

            return doctors;
        }

        public Patient GetPatientBy(string id)
        {
            Patient patient = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user")
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

        public WorkDay GetWorkDayBy(string id, DateTime date)
        {
            WorkDay workDay = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user")
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

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "8081";

            return $"http://{origin}:{port}";
        }

    }
}
