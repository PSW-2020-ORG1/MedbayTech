
using MedbayTech.Appointment.Application.Gateways;
using MedbayTech.Appointment.Domain.Entities;
using MedbayTech.Common.Application.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MedbayTech.Appointment.Infrastructure.Gateway
{
    public class UserGateway : IUserGateway
    {
        public Doctor GetDoctorBy(string id)
        {
            Doctor doctor = null;
            using HttpClient client = new HttpClient();
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

        public List<Doctor> GetDoctorsBy(int specializationId)
        {
            List<Doctor> doctors = new List<Doctor>();
            using HttpClient client = new HttpClient();

            var task = client.GetAsync(GetUsersDomain() + "/api/doctor/specialization/" + specializationId)
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

        public WorkDay GetWorkDayBy(string id, DateTime date)
        {
            WorkDay workDay = null;
            WorkDayDTO dto = new WorkDayDTO(id, date);
            using HttpClient client = new HttpClient();
            string serializedDto = JsonConvert.SerializeObject(dto);

            var content = new StringContent(serializedDto, Encoding.UTF8, "application/json");
           
            var task = client.PostAsync(GetUsersDomain() + "/api/workDay/", content)
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

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/doctor/getAllDoctors")
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

        public string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_USERS") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_USERS") ?? "8081";

            return $"http://{origin}:{port}";
        }

       
    }
}
