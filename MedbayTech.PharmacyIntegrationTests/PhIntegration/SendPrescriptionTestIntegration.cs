using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using MedbayTech.Pharmacies.Application.DTO;
using MedbayTech.Pharmacies;
using System.Text;

namespace MedbayTech.PharmacyIntegrationTests.PhIntegration
{
    public class SendPrescriptionTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public SendPrescriptionTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async void Send_prescription_integration()
        {
            Console.WriteLine("Started prescription testing");
            HttpClient client = _factory.CreateClient();
            var prescription = CreatePrescription();
            StringContent content = new StringContent(JsonConvert.SerializeObject(prescription), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Prescription", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.BadRequest);
        }

        private PrescriptionForSendingDTO CreatePrescription()
        {
            PrescriptionForSendingDTO prescription = new PrescriptionForSendingDTO
            {
                PatientId = "123456789",
                PatientName = "Radovan",
                PatientSurname = "Zapunski",
                MedicationName = "Aspirin",
                MedicationDosage = "300mg",
                MedicationHourlyIntake = 4,
                DoctorName = "Pera",
                DoctorSurname = "Peric",
                Date = new DateTime(2021, 1, 1),
            };
            return prescription;
        }
    }
}
