using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using MedbayTech.Tenders;

namespace IntegrationTests.PhIntegration
{
    public class MakeTenderOfferTestIntegration : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public MakeTenderOfferTestIntegration(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async void Create_new_tender()
        {
            Console.WriteLine("Started creating new tender offer");
            HttpClient client = _factory.CreateClient();
            var offer = CreateNewOffer();
            StringContent content = new StringContent(JsonConvert.SerializeObject(offer), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/TenderOffer/makeOffer", content);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        private TenderOffer CreateNewOffer()
        {
            TenderOffer tender = new TenderOffer
            {
                TenderId = 1,
                Pharmacy = "Zelena Apoteka",
                PharmacyEMail = "zelana@zp.rs",
                TenderOfferPrice = 5500,
            };
            return tender;
        }
    }
}
