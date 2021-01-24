using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using System.Collections.Generic;
using MedbayTech.Tenders.Application.DTO;
using MedbayTech.Tenders;

namespace IntegrationTests.PhIntegration
{
    public class CreateNewTenderTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public CreateNewTenderTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async void Create_new_tender()
        {
            // TODO(Jovan): How to start pharmacies server?
            Console.WriteLine("Started tender creating");
            HttpClient client = _factory.CreateClient();
            var tender = CreateTenderDTO();
            StringContent content = new StringContent(JsonConvert.SerializeObject(tender), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Tender", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private TenderDTO CreateTenderDTO()
        {
            List<TenderMedicationDTO> medications = new List<TenderMedicationDTO>();
            medications.Add(new TenderMedicationDTO(5, "Brufen", "200mg", 100));
            TenderDTO tender = new TenderDTO
            {
                EndDate = new DateTime(2021, 6, 1),
                tenderMedications = medications,
                TenderDescription = "Tender for brufen",
            };
            return tender;
        }
    }
}
