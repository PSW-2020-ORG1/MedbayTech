using MedbayTech.Tenders.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Tenders.Domain.Entities.Tenders;
using Microsoft.AspNetCore.Mvc;

namespace MedbayTech.Tenders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOfferController : Controller
    {
        private readonly ITenderOfferService _tenderOfferService;

        public TenderOfferController(ITenderOfferService tenderOfferService)
        {
            _tenderOfferService = tenderOfferService;
        }

        [HttpGet("tender/{id?}")]
        public IActionResult Get(int id)
        {
            return Ok(_tenderOfferService.GelAllForTender(id));
        }

        [HttpPost("makeOffer")]
        public IActionResult MakeOffer(TenderOffer tenderOffer)
        {
            bool isTenderOfferSuccessfullyAdded = _tenderOfferService.Add(tenderOffer) != null;

            if (isTenderOfferSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

    }
}
