using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.IO;

namespace MedbayTech.Tenders.Infrastructure.Service.Tenders
{
    public class RssService : IRssService
    {

        private readonly ITenderService _tenderService;
        private readonly ITenderOfferService _tenderOfferService;

        public RssService(ITenderService tenderService, ITenderOfferService tenderOfferService)
        {
            _tenderService = tenderService;
            _tenderOfferService = tenderOfferService;
        }

        public MemoryStream GenerateTenderRss()
        {
            var feed = new SyndicationFeed("Tender Feed", "Feed for tenders", new Uri(GetPharmacyDomain() + "/dean/activeTender"), "Tenders", DateTime.Now);
            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} Medbay-Tech Hospital");

            var items = new List<SyndicationItem>();
            var postings = _tenderService.GetAll();

            foreach (var item in postings)
            {
                if (item.TenderStatus == Domain.Enums.TenderStatus.Active)
                {
                    items.Add(GetActiveSyndication(item));
                }
                else if(item.TenderStatus == Domain.Enums.TenderStatus.Finished)
                {
                    items.Add(GetWinnerSyndication(item));
                }
            }

            feed.Items = items;
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NewLineHandling = NewLineHandling.Entitize,
                NewLineOnAttributes = true,
                Indent = true
            };
            using (var stream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    var rssFormatter = new Rss20FeedFormatter(feed, false);
                    rssFormatter.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                }
                return stream;
            }
        }

        private SyndicationItem GetActiveSyndication(Tender tender)
        {
            string id = "" + tender.Id;
            var title = tender.TenderDescription;
            string data = tender.ToString();
            data += "\n\nTo see more details wisit our site.\n#Medbay-Tech Hospital#\n";
            TextSyndicationContent textContent = new TextSyndicationContent(data);
            return new SyndicationItem(title, textContent, new Uri(GetPharmacyDomain() + "/dean/activeTender"),
                id, tender.EndDate);
        }

        private SyndicationItem GetWinnerSyndication(Tender tender)
        {
            TenderOffer tenderOffer = _tenderOfferService.Get(tender.WinnerTenderOfferId);
            string id = "" + tender.Id;
            var title = " Winner for " + tender.TenderDescription;
            string data = "Winner for this tender is " + tenderOffer.Pharmacy + ".";
            data += "\n\nTo see more details wisit our site.\n#Medbay-Tech Hospital#\n";
            TextSyndicationContent textContent = new TextSyndicationContent(data);
            return new SyndicationItem(title, textContent, new Uri(GetPharmacyDomain() + "/dean/activeTender"),
                id, tender.EndDate);
        }

        private string GetPharmacyDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL_PHARMACIES") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT_PHARMACIES") ?? "50202";

            return $"http://{origin}:{port}";
        }

    }
}
