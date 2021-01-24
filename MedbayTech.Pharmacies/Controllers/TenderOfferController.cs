using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Mailing;
using MedbayTech.Pharmacies.Application.Common.Interfaces.Service.Tenders;
using MedbayTech.Pharmacies.Application.DTO;
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
        private readonly IMailService _mailService;

        public TenderOfferController(ITenderOfferService tenderOfferService, IMailService mailService)
        {
            _tenderOfferService = tenderOfferService;
            _mailService = mailService;
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
            {
                SendMail(tenderOffer.PharmacyEMail);
                return Ok();
            }
            else
                return BadRequest();
        }

        private void SendMail(String email)
        {
            MailRequestDTO mailRequest = new MailRequestDTO { ToEmail = email, Subject = "Message from Medbay hospital", Body = "Made an offer from MedbayTech hospital!" };
            _mailService.SendMailAsync(mailRequest).Wait();
        }

    }
}
