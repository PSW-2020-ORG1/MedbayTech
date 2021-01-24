using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace MedbayTech.Tenders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : Controller
    {

        private readonly ITenderService _tenderService;
        private readonly ITenderOfferService _tenderOfferService;

        public RssController(ITenderService tenderService, ITenderOfferService tenderOfferService)
        {
            _tenderService = tenderService;
            _tenderOfferService = tenderOfferService;
        }

        [ResponseCache(Duration = 1200)]
        [HttpGet]
        public IActionResult Rss()
        {
            var feed = new SyndicationFeed("Tender Feed", "Feed for tenders", new Uri("http://localhost:50202/dean/activeTender"), "Tenders", DateTime.Now);
            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} Medbay-Tech Hospital");

            var items = new List<SyndicationItem>();
            var postings = _tenderService.GetAll();

            foreach (var item in postings)
            {
                if (item.TenderStatus == Domain.Enums.TenderStatus.Active)
                {
                    //var postUrl = Url.Action("Article", "Blog", new { id = item.UrlSlug }, HttpContext.Request.Scheme);
                    string id = "" + item.Id;
                    var title = item.TenderDescription;
                    string data = item.ToString();
                    data += "\n\nTo see more details wisit our site.\n#Medbay-Tech Hospital#\n";
                    TextSyndicationContent textContent = new TextSyndicationContent(data);
                    items.Add(new SyndicationItem(title, textContent, new Uri("http://localhost:50202/dean/activeTender"), id, item.EndDate));
                }
            }
            foreach (var item in postings)
            {
                if (item.TenderStatus == Domain.Enums.TenderStatus.Finished)
                {
                    //var postUrl = Url.Action("Article", "Blog", new { id = item.UrlSlug }, HttpContext.Request.Scheme);
                    TenderOffer tenderOffer = _tenderOfferService.Get(item.WinnerTenderOfferId);
                    string id = "" + item.Id;
                    var title = " Winner for " + item.TenderDescription;
                    string data = "Winner for this tender is " + tenderOffer.Pharmacy + ".";
                    data += "\n\nTo see more details wisit our site.\n#Medbay-Tech Hospital#\n";
                    TextSyndicationContent textContent = new TextSyndicationContent(data);
                    items.Add(new SyndicationItem(title, textContent, new Uri("http://localhost:50202/dean/activeTender"), id, item.EndDate));
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
                return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
            }

        }

    }
}
