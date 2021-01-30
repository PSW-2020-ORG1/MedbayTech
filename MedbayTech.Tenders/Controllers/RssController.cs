using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Tenders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : Controller
    {

        private readonly IRssService _rssService;
        public RssController(IRssService rssService)
        {
            _rssService = rssService;
        }

        [ResponseCache(Duration = 1200)]
        [HttpGet]
        public IActionResult Rss()
        {
            return File(_rssService.GenerateTenderRss().ToArray(), "application/rss+xml; charset=utf-8");
        }

    }
}
