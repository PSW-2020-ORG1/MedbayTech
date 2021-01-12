using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Pharmacies.Domain.Entities.Tenders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedbayTech.Pharmacies.Controllers
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
        public IActionResult DeclareWinner(TenderOffer tenderOffer)
        {
            bool isTenderOfferSuccessfullyAdded = _tenderOfferService.Add(tenderOffer) != null;

            if (isTenderOfferSuccessfullyAdded)
                return Ok();
            else
                return BadRequest();
        }

    }
}
