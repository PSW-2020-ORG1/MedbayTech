using MedbayTech.PatientDocuments.Application.DTO.Report;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using MedbayTech.PatientDocuments;
using MedbayTech.WebIntegrationTests.WebApplicationFactory;
using Xunit;

namespace MedbayTech.WebIntegrationTests.Reports
{
    public class ReportsTestIntegration : IClassFixture<MedicalRecordService>, IClassFixture<LoginService>
    {
        private readonly MedicalRecordService _factoryMedicalRecordService;
        private readonly LoginService _factoryLoginService;


        public ReportsTestIntegration(MedicalRecordService factoryMedicalRecordService, LoginService factoryLoginService)
        {
            _factoryMedicalRecordService = factoryMedicalRecordService;
            _factoryLoginService = factoryLoginService;
        }

        [Fact]
        public async System.Threading.Tasks.Task Get_Report_For_Appointment_IntegrationAsync()
        {
            Console.Write("Started Get_Report_For_Appointment_IntegrationAsync");
            HttpClient client = _factoryMedicalRecordService.CreateClient();
            string token = _factoryLoginService.Login("pera", "pera1978");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var appointment = Appointment();
            StringContent content = new StringContent(JsonConvert.SerializeObject(appointment), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/report/appointmentReport", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            Console.Write("Finished Get_Report_For_Appointment_IntegrationAsync");

        }

        private static AppointmentDTO Appointment()
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO
            {
                StartTime = new DateTime(2020, 12, 4, 14, 00, 0),
                DoctorId = "2406978890047"
            };
            return appointmentDTO;
        }
    }
}
