using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using MedbayTech.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using MedbayTech.Tenders.Domain.Enums;

namespace IntegrationTests.PhIntegration
{
    public class DeclareTenderWinnerTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public DeclareTenderWinnerTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async void Declare_tender_winner()
        {
            Console.WriteLine("Started testing");
            HttpClient client = _factory.CreateClient();
            var tender = CreateTender();
            StringContent content = new StringContent(JsonConvert.SerializeObject(tender), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/Tender/winner", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private Tender CreateTender()
        {
            Tender tender = new Tender
            {
                Id = 1,
                StartDate = new DateTime(2020, 12, 30),
                EndDate = new DateTime(2021, 5, 1),
                TenderDescription = "Tender for Xanax, Diazepam, Panadon and Flobian",
                TenderStatus = TenderStatus.Finished,
                WinnerTenderOfferId = 1,
            };
            return tender;
        }
    }
}
